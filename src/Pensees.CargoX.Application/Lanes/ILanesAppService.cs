using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.Lanes.Dto;

namespace Pensees.CargoX.Lanes
{
    public interface ILanesAppService : IApplicationService
    {
        Task<ListResultDto<LaneDto>> QueryByParams(Dictionary<string, string> parameters);
    }
}
