using System.Collections.Generic;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.Tollgates.Dto;
using System.Threading.Tasks;

namespace Pensees.CargoX.Tollgates
{
    public interface ITollgatesAppService : IApplicationService
    {
        Task<ListResultDto<TollgateDto>> QueryByParams(Dictionary<string,string> parameters);
    }
}
