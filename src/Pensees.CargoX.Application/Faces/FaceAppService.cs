using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Faces.Dto;
using Pensees.CargoX.Repository.Faces;

namespace Pensees.CargoX.Faces
{
    public class FaceAppService : AsyncCrudAppService<Face, FaceRequiredDto, long, PagedResultRequestDto, FaceRequiredDto, FaceRequiredDto>, IFaceAppService
    {
        private readonly IFaceRepository _faceRepository;
        public FaceAppService(IFaceRepository faceRepository) : base(faceRepository)
        {
            _faceRepository = faceRepository;
        }

        public async Task<ListResultDto<FaceDto>> QuesyByParams(Dictionary<string, string> parameters)
        {
            var faces = await _faceRepository.QueryByParams(parameters).ConfigureAwait(false);
            return new ListResultDto<FaceDto>(ObjectMapper.Map<List<FaceDto>>(faces));
        }
    }
}
