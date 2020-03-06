using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.APEs.Dto;
using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.APEs
{
    public interface IAPEsAppService:IApplicationService
    {
        Task<PagedResultDto<ApeDto>> QueryApesWithCondition(string condition);
        Task<ResponseStatusList> UpdateApes(List<ApeDto> apeDtos);
    }
}
