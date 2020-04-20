using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pensees.CargoX.Common;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Faces.Dto;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Repository.Faces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Pensees.CargoX.Common.Dto;
using System.Linq;
using MassTransit;
using Shared.Events;

namespace Pensees.CargoX.Faces
{
    public class FacesAppService : CargoXAsyncCrudAppService<Face, FaceDto, long, PagedAndSortedResultRequestDto, FaceDto, FaceDto>, IFacesAppService
    {
        private readonly IFaceRepository _faceRepository;
        private readonly IImageAppService _imageAppService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IPublishEndpoint _publishEndpoint;
        public FacesAppService(
            IFaceRepository faceRepository,
            IImageAppService imageAppService,
            IHttpContextAccessor httpContext,
            IPublishEndpoint publishEndpoint) : base(faceRepository)
        {
            _faceRepository = faceRepository;
            _imageAppService = imageAppService;
            _httpContext = httpContext;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<PagedResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(PagedAndSortedRequestDto input)
        {
            var query = _faceRepository.GetAllIncluding(p => p.SubImageInfos);
            query = await _faceRepository.QueryByParams(input.Parameters,query).ConfigureAwait(false);
            //var faces = await GetAllAsync(input).ConfigureAwait(false);
            var faces = PagingAndSorting(input, query);
            if (input.ImageRequred==1)
            {
                foreach (var face in faces.Items)
                {
                    var imageToQuery = face.SubImageList.SubImageInfoObject;
                    //imageType
                    if (input.ImageType == "11" || input.ImageType == "14")
                    {
                        imageToQuery = imageToQuery.Where(p => p.Type == input.ImageType).ToList();
                    }
                    foreach (var subImageInfo in imageToQuery)
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
            }
            
            return new PagedResultDto<ClusteringFaceDto>(faces.TotalCount,ObjectMapper.Map<List<ClusteringFaceDto>>(faces.Items));
        }

        [Route("VIID/Faces")]
        [HttpGet]
        public async Task<PagedResultDto<FaceDto>> QueryClusteringFaceWithContition(string condition)
        {
            //QueryString queryString = _httpContext.HttpContext.Request.QueryString;
            //string decodedQueryStr = WebUtility.UrlDecode(queryString.Value);
            PagedAndSortedRequestDto input = new PagedAndSortedRequestDto();
            var queryString = GetQueryStringAndPagingParameters(condition, input);
            var query = _faceRepository.GetAllIncluding(p => p.SubImageInfos);
            query = await _faceRepository.QueryByConditions(queryString,query).ConfigureAwait(false);
            var result= PagingAndSorting(input, query);
            foreach (var item in result.Items)
            {
                await _imageAppService.GetSubImageInfoDtoList(item.SubImageList.SubImageInfoObject);
            }
            return new PagedResultDto<FaceDto>(result.TotalCount,ObjectMapper.Map<List<FaceDto>>(result.Items));
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
            var result= await base.CreateAsync(input);
            var face = ObjectMapper.Map<Face>(input);
            await _publishEndpoint.Publish(new FaceEvent
            {
                //需要获取device
                DeviceId = face.DeviceId,
                Entity = face
            });

            return result;
        }
        public override async Task<ResponseStatusList> CreateList(CreateOrUpdateListInputDto<FaceDto> input)
        {
            ResponseStatusList result = new ResponseStatusList();
            foreach (var faceDto in input.List)
            {
                foreach (var subImageInfoDto in faceDto.SubImageList.SubImageInfoObject)
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
                var face = await base.CreateAsync(faceDto);
                result.ResponseStatusObject.Add(new ResponseStatus
                {
                    Id = face.Id.ToString(),
                    RequestURL = "",
                    StatusCode = 0,
                    StatusString = "",
                    LocalTime = DateTime.Now
                });
            }
            return result;
        }

        public override async Task<FaceDto> GetAsync(EntityDto<long> input)
        {
            Face face = await _faceRepository.GetAllIncluding(t => t.SubImageInfos)
                .SingleOrDefaultAsync(f => f.Id == input.Id).ConfigureAwait(false);

            if (face?.SubImageInfos != null)
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
        [HttpPut]
        public override async Task<ResponseStatusList> UpdateList(CreateOrUpdateListInputDto<FaceDto> input)
        {
            ResponseStatusList result = new ResponseStatusList();
            foreach (var item in input.List)
            {
                var dto = await base.UpdateAsync(item);
                result.ResponseStatusObject.Add(new ResponseStatus
                {
                    Id = dto.Id.ToString(),
                    RequestURL = "",
                    StatusCode = 0,
                    StatusString = "",
                    LocalTime = DateTime.Now
                });
            }
            return result;
        }

        public override Task<FaceDto> UpdateAsync(FaceDto input)
        {
            return base.UpdateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<long> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<FaceDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        [HttpDelete]
        public override async Task<ResponseStatusList> DeleteList(string input)
        {
            ResponseStatusList result = new ResponseStatusList();
            var ids = input.Split(',');
            long id;
            foreach (var item in ids)
            {
                if (!long.TryParse(item, out id))
                {
                    continue;
                }
                await base.DeleteAsync(new EntityDto<long> { Id = id });
                result.ResponseStatusObject.Add(new ResponseStatus
                {
                    Id = item,
                    RequestURL = "",
                    StatusCode = 0,
                    StatusString = "",
                    LocalTime = DateTime.Now
                });
            }
            return result;
        }

        //protected override IQueryable<Face> CreateFilteredQuery(PagedAndSortedRequestDto input)
        //{
        //    var query= _faceRepository.QueryByParams(input.Parameters, _faceRepository.GetAllIncluding(p => p.SubImageInfos)).Result;
        //    return query;
        //}

    }
}
