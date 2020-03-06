using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.MotorVehicles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.MotorVehicles
{
    public interface IMotorVehiclesAppService:IApplicationService
    {
        Task<PagedResultDto<MotorDto>> QueryClusteringMotorWithContition(string condition);
    }
}
