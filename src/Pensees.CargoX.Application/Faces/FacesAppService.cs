using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Faces.Dto;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository.Faces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pensees.CargoX.Faces
{
    public class FacesAppService : AsyncCrudAppService<Face, FaceDto, long, PagedResultRequestDto, FaceDto, FaceDto>, IFacesAppService
    {
        private readonly IFaceRepository _faceRepository;
        private readonly IRepository<SubImageInfo, long> _subImageInfoRepository;
        private readonly IImageAppService _imageAppService;
        private readonly IHttpContextAccessor _httpContext;

        public FacesAppService(
            IFaceRepository faceRepository,
            IImageAppService imageAppService,
            IHttpContextAccessor httpContext) : base(faceRepository)
        {
            _faceRepository = faceRepository;
            _imageAppService = imageAppService;
            _httpContext = httpContext;
        }

        public async Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(Dictionary<string, Dictionary<string, string>> parameters)
        {
            var faces = await _faceRepository.QueryByParams(parameters,_faceRepository.GetAllIncluding(p=>p.SubImageInfos)).ConfigureAwait(false);
            foreach (var face in faces)
            {
                foreach (var subImageInfo in face.SubImageInfos)
                {
                    if (string.IsNullOrEmpty(subImageInfo.ImageKey) ||
                        string.IsNullOrEmpty(subImageInfo.NodeId))
                    {
                        continue;
                    }

                    GetImageRequest request = new GetImageRequest()
                    {
                        BucketName = subImageInfo.NodeId,
                        ImageName = subImageInfo.ImageKey
                    };

                    GetImageWithBytesResponse response = await _imageAppService.GetImageWithBytesAsync(request).ConfigureAwait(false);
                    subImageInfo.Data = Convert.ToBase64String(response.ImageData);
                }
            }
            return new ListResultDto<ClusteringFaceDto>(ObjectMapper.Map<List<ClusteringFaceDto>>(faces));
        }

        [Route("VIID/Faces")]
        [HttpGet]
        public Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceWithContition(string condition)
        {
            QueryString queryString = _httpContext.HttpContext.Request.QueryString;
            string decodedQueryStr = WebUtility.UrlDecode(queryString.Value);
            return null;
        }

        public override async Task<FaceDto> CreateAsync(FaceDto input)
        {
            foreach (var subImageInfoDto in input.SubImageList.SubImageInfoObject)
            {
                if (string.IsNullOrEmpty(subImageInfoDto.Data))
                {
                    continue;
                }

                SaveImageByBase64Request request = new SaveImageByBase64Request()
                {
                    ImageBase64 = subImageInfoDto.Data
                };
                
                SaveImageResponse response = await _imageAppService.SaveImageByBase64Async(request);

                subImageInfoDto.NodeId = response.BucketName;
                subImageInfoDto.ImageKey = response.ImageName;
                subImageInfoDto.StoragePath = $"{response.BucketName}:{response.ImageName}";
            }

            return await base.CreateAsync(input);
        }

        public override async Task<FaceDto> GetAsync(EntityDto<long> input)
        {
            Face face = await _faceRepository.GetAllIncluding(t => t.SubImageInfos)
                .SingleOrDefaultAsync(f => f.Id == input.Id).ConfigureAwait(false);

            if (face.SubImageInfos != null)
            {
                foreach (var subImageInfo in face.SubImageInfos)
                {
                    if (string.IsNullOrEmpty(subImageInfo.ImageKey) || 
                        string.IsNullOrEmpty(subImageInfo.NodeId))
                    {
                        continue;
                    }

                    GetImageRequest request = new GetImageRequest()
                    {
                        BucketName = subImageInfo.NodeId,
                        ImageName = subImageInfo.ImageKey
                    };

                    GetImageWithBytesResponse response = await _imageAppService.GetImageWithBytesAsync(request).ConfigureAwait(false);
                    subImageInfo.Data = Convert.ToBase64String(response.ImageData);
                }
            }

            var faceDto = MapToEntityDto(face);
            //faceDto.SubImageList = new SubImageInfoDtoList();
            //faceDto.SubImageList.SubImageInfoObject = faceDto.SubImageInfos;
            //faceDto.SubImageInfos = null;

            return faceDto;
        }

        public override Task<FaceDto> UpdateAsync(FaceDto input)
        {
            return base.UpdateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<long> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<FaceDto>> GetAllAsync(PagedResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        public ClusteringFaceDto TestQueryByParams(Dictionary<string, Dictionary<string,string>> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
