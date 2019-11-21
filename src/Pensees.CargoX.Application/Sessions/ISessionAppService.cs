using System.Threading.Tasks;
using Abp.Application.Services;
using Pensees.CargoX.Sessions.Dto;

namespace Pensees.CargoX.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
