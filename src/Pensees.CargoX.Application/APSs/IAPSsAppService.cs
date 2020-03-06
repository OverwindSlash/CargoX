using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.APSs.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.APSs
{
    public interface IAPSsAppService:IApplicationService
    {
        Task<PagedResultDto<ApsDto>> QueryApssWithCondition(string condition);
    }
}
