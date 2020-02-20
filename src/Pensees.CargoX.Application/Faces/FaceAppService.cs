using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Entities.Common;
using Pensees.CargoX.Faces.Dto;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository.Faces;

namespace Pensees.CargoX.Faces
{
    public class FaceAppService : AsyncCrudAppService<Face, FaceDto, long, PagedResultRequestDto, FaceDto, FaceDto>, IFaceAppService
    {
        private readonly IFaceRepository _faceRepository;
        private readonly IRepository<SubImageInfo, long> _subImageInfoRepository;
        private readonly IImageAppService _imageAppService;

        public FaceAppService(
            IFaceRepository faceRepository,
            IImageAppService imageAppService) : base(faceRepository)
        {
            _faceRepository = faceRepository;
            _imageAppService = imageAppService;
        }

        public async Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(Dictionary<string, string> parameters)
        {
            var faces = await _faceRepository.QueryByParams(parameters).ConfigureAwait(false);
            return new ListResultDto<ClusteringFaceDto>(ObjectMapper.Map<List<ClusteringFaceDto>>(faces));
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
            faceDto.SubImageList = new SubImageInfoDtoList();
            faceDto.SubImageList.SubImageInfoObject = faceDto.SubImageInfos;
            faceDto.SubImageInfos = null;

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
    }
}
