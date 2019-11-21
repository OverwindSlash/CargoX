using System.Threading.Tasks;
using Abp.Application.Services;
using Pensees.CargoX.Authorization.Accounts.Dto;

namespace Pensees.CargoX.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
