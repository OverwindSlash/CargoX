using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.MotorVehicles.Dto;
using Pensees.CargoX.Repository.MotorVehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.MotorVehicles
{
    public class MotorVehicleAppService:CargoXAsyncCrudAppService<Motor,MotorDto,long, PagedAndSortedRequestDto,MotorDto,MotorDto>,IMotorVehicleAppService
    {
        private readonly IMotorVehicleRepository _motorVehicleRepository;
        private readonly IImageAppService _imageAppService;

        public MotorVehicleAppService(IMotorVehicleRepository motorVehicleRepository, 
            IImageAppService imageAppService) : base(motorVehicleRepository)
        {
            _motorVehicleRepository = motorVehicleRepository;
            _imageAppService = imageAppService;
        }

        [Route("VIID/MotorVehicles")]
        [HttpGet]
        public async Task<PagedResultDto<MotorDto>> QueryClusteringMotorWithContition(string condition)
        {
            PagedAndSortedRequestDto input = new PagedAndSortedRequestDto();
            var queryString = GetQueryStringAndPagingParameters(condition, input);
            var query = await _motorVehicleRepository.QueryByConditions(queryString).ConfigureAwait(false);
            var result = PagingAndSorting(input, query);
            return new PagedResultDto<MotorDto>(result.TotalCount, ObjectMapper.Map<List<MotorDto>>(result.Items));
        }

        public override async Task<MotorDto> GetAsync(EntityDto<long> input)
        {
            var entity = await _motorVehicleRepository.GetAllIncluding(t => t.SubImageInfos)
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

        public override async Task<MotorDto> CreateAsync(MotorDto input)
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

        public override async Task<ResponseStatusList> CreateList(CreateOrUpdateListInputDto<MotorDto> input)
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
        public override async Task<ResponseStatusList> UpdateList(CreateOrUpdateListInputDto<MotorDto> input)
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
