using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.NonMotorVehicles.Dto;
using Pensees.CargoX.Repository.NonMotorVehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.NonMotorVehicles
{
    public class NonMotorVehiclesAppService : CargoXAsyncCrudAppService<NonMotor, NonMotorDto, long, PagedAndSortedRequestDto, NonMotorDto, NonMotorDto>, INonMotorVehiclesAppService
    {
        private readonly INonMotorVehicleRepository _nonMotorVehicleRepository;
        private readonly IImageAppService _imageAppService;
        public NonMotorVehiclesAppService(INonMotorVehicleRepository nonMotorVehicleRepository,
            IImageAppService imageAppService) :base(nonMotorVehicleRepository)
        {
            _nonMotorVehicleRepository = nonMotorVehicleRepository;
            _imageAppService = imageAppService;
        }

        [Route("VIID/NonMotorVehicles")]
        [HttpGet]
        public async Task<PagedResultDto<NonMotorDto>> QueryNonMotorsWithContition(string condition)
        {
            PagedAndSortedRequestDto input = new PagedAndSortedRequestDto();
            var queryString = GetQueryStringAndPagingParameters(condition, input);
            var query = await _nonMotorVehicleRepository.QueryByConditions(queryString).ConfigureAwait(false);
            var result = PagingAndSorting(input, query);
            return new PagedResultDto<NonMotorDto>(result.TotalCount, ObjectMapper.Map<List<NonMotorDto>>(result.Items));
        }
        public override async Task<NonMotorDto> GetAsync(EntityDto<long> input)
        {
            var entity = await _nonMotorVehicleRepository.GetAllIncluding(t => t.SubImageInfos)
                .SingleOrDefaultAsync(f => f.Id == input.Id).ConfigureAwait(false);

            if (entity?.SubImageInfos != null)
            {
                foreach (var subImageInfo in entity.SubImageInfos)
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

                    GetImageWithBytesResponse response = await _imageAppService.GetImageWithBytesAsync(request);
                    subImageInfo.Data = Convert.ToBase64String(response.ImageData);
                }
            }
            var dto = MapToEntityDto(entity);
            return dto;
        }

        public override async Task<NonMotorDto> CreateAsync(NonMotorDto input)
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

        public override async Task<ResponseStatusList> CreateList(CreateOrUpdateListInputDto<NonMotorDto> input)
        {
            ResponseStatusList result = new ResponseStatusList();
            foreach (var dto in input.List)
            {
                foreach (var subImageInfoDto in dto.SubImageList.SubImageInfoObject)
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
                var face = await base.CreateAsync(dto).ConfigureAwait(false);
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

        [HttpPut]
        public override async Task<ResponseStatusList> UpdateList(CreateOrUpdateListInputDto<NonMotorDto> input)
        {
            ResponseStatusList result = new ResponseStatusList();
            foreach (var item in input.List)
            {
                var dto = await base.UpdateAsync(item).ConfigureAwait(false);
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
                await base.DeleteAsync(new EntityDto<long> { Id = id }).ConfigureAwait(false);
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
    }
}
