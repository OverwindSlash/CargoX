using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.NonMotorVehicles.Dto;
using Pensees.CargoX.Repository.NonMotorVehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.NonMotorVehicles
{
    public class NonMotorVehicleAppService : CargoXAsyncCrudAppService<NonMotor, NonMotorDto, long, PagedAndSortedRequestDto, NonMotorDto, NonMotorDto>, INonMotorVehicleAppService
    {
        private readonly INonMotorVehicleRepository _nonMotorVehicleRepository;

        public NonMotorVehicleAppService(INonMotorVehicleRepository nonMotorVehicleRepository):base(nonMotorVehicleRepository)
        {
            _nonMotorVehicleRepository = nonMotorVehicleRepository;
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
    }
}
