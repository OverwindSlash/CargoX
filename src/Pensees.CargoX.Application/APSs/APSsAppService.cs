using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Pensees.CargoX.APSs.Dto;
using Pensees.CargoX.Common;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Repository.Apss;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.APSs
{
    public class APSsAppService : ApplicationService, IAPSsAppService
    {
        private readonly IApsRepository _apsRepository;

        public APSsAppService(IApsRepository apsRepository)
        {
            _apsRepository = apsRepository;
        }
        [Route("VIID/APSs")]
        [HttpGet]
        public async Task<PagedResultDto<ApsDto>> QueryApssWithCondition(string condition)
        {
            PagedAndSortedRequestDto input = new PagedAndSortedRequestDto();
            var queryString = QueryHelper<Aps, long, ApsDto>.GetQueryStringAndPagingParameters(condition, input);
            var query = await _apsRepository.QueryByConditions(queryString).ConfigureAwait(false);
            var result = QueryHelper<Aps, long, ApsDto>.PagingAndSorting(input, query);
            return new PagedResultDto<ApsDto>(result.TotalCount, ObjectMapper.Map<List<ApsDto>>(result.Items));
        }
    }
}
