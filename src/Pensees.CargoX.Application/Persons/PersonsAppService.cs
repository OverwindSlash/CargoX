using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Images;
using Pensees.CargoX.Images.Dtos;
using Pensees.CargoX.Persons.Dto;
using Pensees.CargoX.Repository.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pensees.CargoX.Persons
{
    public class PersonsAppService : CargoXAsyncCrudAppService<Person, PersonDto, long, PagedAndSortedResultRequestDto, PersonDto, PersonDto>, IPersonsAppService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IImageAppService _imageAppService;

        public PersonsAppService(IPersonRepository personRepository, IImageAppService imageAppService):base(personRepository)
        {
            _personRepository = personRepository;
            _imageAppService = imageAppService;
        }

        public async Task<PagedResultDto<ClusteringPersonDto>> QueryClusteringPersonByParams(PagedAndSortedRequestDto input)
        {
            var query = _personRepository.GetAllIncluding(p => p.SubImageInfos);
            query = await _personRepository.QueryByParams(input.Parameters, query).ConfigureAwait(false);
            var persons = PagingAndSorting(input, query);
            if (input.ImageRequred == 1)
            {
                foreach (var person in persons.Items)
                {
                    var imageToQuery = person.SubImageList.SubImageInfoObject;
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
            return new PagedResultDto<ClusteringPersonDto>(persons.TotalCount, ObjectMapper.Map<List<ClusteringPersonDto>>(persons.Items));
        }
        [Route("VIID/Persons")]
        [HttpGet]
        public async Task<PagedResultDto<PersonDto>> QueryClusteringMotorWithContition(string condition)
        {
            PagedAndSortedRequestDto input = new PagedAndSortedRequestDto();
            var queryString = GetQueryStringAndPagingParameters(condition, input);
            var query = await _personRepository.QueryByConditions(queryString).ConfigureAwait(false);
            var result = PagingAndSorting(input, query);
            return new PagedResultDto<PersonDto>(result.TotalCount, ObjectMapper.Map<List<PersonDto>>(result.Items));
        }

        public override async Task<PersonDto> CreateAsync(PersonDto input)
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

        public override async Task<PersonDto> GetAsync(EntityDto<long> input)
        {
            Person person = await _personRepository.GetAllIncluding(t => t.SubImageInfos)
                .SingleOrDefaultAsync(f => f.Id == input.Id).ConfigureAwait(false);

            if (person?.SubImageInfos != null)
            {
                foreach (var subImageInfo in person.SubImageInfos)
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

            var PersonDto = MapToEntityDto(person);
            return PersonDto;
        }

        public override Task<PersonDto> UpdateAsync(PersonDto input)
        {
            return base.UpdateAsync(input);
        }

        public override Task DeleteAsync(EntityDto<long> input)
        {
            return base.DeleteAsync(input);
        }

        public override Task<PagedResultDto<PersonDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }
        
        public override async Task<ResponseStatusList> CreateList(CreateOrUpdateListInputDto<PersonDto> input)
        {
            ResponseStatusList result = new ResponseStatusList();
            foreach (var item in input.List)
            {
                foreach (var subImageInfoDto in item.SubImageList.SubImageInfoObject)
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
                var face = await base.CreateAsync(item);
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
        public override async Task<ResponseStatusList> UpdateList(CreateOrUpdateListInputDto<PersonDto> input)
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
    }
}
