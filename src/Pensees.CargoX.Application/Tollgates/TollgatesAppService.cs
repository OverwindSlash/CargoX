using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Repository.Tollgates;
using Pensees.CargoX.Tollgates.Dto;

namespace Pensees.CargoX.Tollgates
{
    public class TollgatesAppService : AsyncCrudAppService<Tollgate, TollgateDto, long, PagedTollgateResultRequestDto, TollgateDto, TollgateDto>, ITollgatesAppService
    {
        private readonly ITollgateRepository _tollgateRepository;

        public TollgatesAppService(ITollgateRepository tollgateRepository) : base(tollgateRepository)
        {
            _tollgateRepository = tollgateRepository;
        }

        public async Task<ListResultDto<TollgateDto>> QuesyByParams(Dictionary<string, string> parameters)
        {
            var tollgates = await _tollgateRepository.QueryByParams(parameters).ConfigureAwait(false);
            return new ListResultDto<TollgateDto>(ObjectMapper.Map<List<TollgateDto>>(tollgates));
        }
    }
}
