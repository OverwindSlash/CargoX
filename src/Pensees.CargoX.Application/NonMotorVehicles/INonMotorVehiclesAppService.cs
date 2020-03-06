using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.NonMotorVehicles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.NonMotorVehicles
{
    public interface INonMotorVehiclesAppService:IApplicationService
    {
        Task<PagedResultDto<NonMotorDto>> QueryNonMotorsWithContition(string condition);
    }
}
