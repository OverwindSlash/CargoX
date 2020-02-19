using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Lanes.Dto;
using Pensees.CargoX.Repository.Lanes;


namespace Pensees.CargoX.Lanes
{
    public class LanesAppService : AsyncCrudAppService<Lane, LaneDto, long, PagedResultRequestDto, LaneDto, LaneDto>, ILanesAppService
    {
        private readonly ILaneRepository _laneRepository;

        public LanesAppService(ILaneRepository laneRepository) : base(laneRepository)
        {
            _laneRepository = laneRepository;
        }

        public async Task<ListResultDto<LaneDto>> QueryByParams(Dictionary<string, string> parameters)
        {
            var lanes = await _laneRepository.QueryByParams(parameters).ConfigureAwait(false);
            return new ListResultDto<LaneDto>(ObjectMapper.Map<List<LaneDto>>(lanes));
        }
    }
}
