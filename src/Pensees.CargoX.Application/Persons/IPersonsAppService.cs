using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Persons.Dto;
using System.Threading.Tasks;

namespace Pensees.CargoX.Persons
{
    public interface IPersonsAppService : IApplicationService
    {
        Task<PagedResultDto<ClusteringPersonDto>> QueryClusteringPersonByParams(PagedAndSortedRequestDto input);
    }
}
