using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Pensees.CargoX.APEs.Dto;
using Pensees.CargoX.Common;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Repository.Apes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.APEs
{
    public class APEsAppService : ApplicationService, IAPEsAppService
    {
        private readonly IApeRepository _apeRepository;

        public APEsAppService(IApeRepository apeRepository)
        {
            _apeRepository = apeRepository;
        }

        [Route("VIID/APEs/")]
        [HttpGet]
        public async Task<PagedResultDto<ApeDto>> QueryApesWithCondition(string condition)
        {
            PagedAndSortedRequestDto input = new PagedAndSortedRequestDto();
            var queryString = QueryHelper<Ape,long,ApeDto>.GetQueryStringAndPagingParameters(condition, input);
            var query = await _apeRepository.QueryByConditions(queryString).ConfigureAwait(false);
            var result = QueryHelper<Ape, long, ApeDto>.PagingAndSorting(input, query);
            return new PagedResultDto<ApeDto>(result.TotalCount, ObjectMapper.Map<List<ApeDto>>(result.Items));
        }
        [Route("VIID/APEs/")]
        [HttpPut]
        public async Task<ResponseStatusList> UpdateApes(List<ApeDto> apeDtos)
        {
            ResponseStatusList result = new ResponseStatusList();
            foreach (var dto in apeDtos)
            {
                var ape = await _apeRepository.GetAsync(dto.Id);
                if (ape == null)
                {
                    continue;
                }
                ObjectMapper.Map(dto,ape);
                //_apeRepository.Update(ape);
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
    }
}
