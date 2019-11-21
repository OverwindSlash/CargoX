using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.MultiTenancy.Dto;

namespace Pensees.CargoX.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

