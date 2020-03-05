using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
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

        public MotorVehicleAppService(IMotorVehicleRepository motorVehicleRepository) : base(motorVehicleRepository)
        {
            _motorVehicleRepository = motorVehicleRepository;
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
    }
}
