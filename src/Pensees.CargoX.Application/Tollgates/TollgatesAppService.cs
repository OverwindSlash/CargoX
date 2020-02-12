using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Tollgates.Dto;

namespace Pensees.CargoX.Tollgates
{
    public class TollgatesAppService : AsyncCrudAppService<Tollgate, TollgateDto, long, PagedTollgateResultRequestDto, TollgateDto, TollgateDto>, ITollgatesAppService
    {
        private readonly IRepository<Tollgate, long> _tollgateRepository;

        public TollgatesAppService(IRepository<Tollgate, long> tollgateRepository) : base(tollgateRepository)
        {
            _tollgateRepository = tollgateRepository;
        }

        public async Task<ListResultDto<TollgateDto>> GetAllTollgates(Dictionary<string, string> parameters)
        {
            var tollgates = await _tollgateRepository.GetAllListAsync().ConfigureAwait(false);
            return new ListResultDto<TollgateDto>(ObjectMapper.Map<List<TollgateDto>>(tollgates));
        }
    }
}
