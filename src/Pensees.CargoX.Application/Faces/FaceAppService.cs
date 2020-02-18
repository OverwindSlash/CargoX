using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities.Faces;
using Pensees.CargoX.Faces.Dto;

namespace Pensees.CargoX.Faces
{
    public class FaceAppService : AsyncCrudAppService<Face, FaceRequiredDto, long, PagedResultRequestDto, FaceRequiredDto, FaceRequiredDto>, IFaceAppService
    {
        public FaceAppService(IRepository<Face, long> repository) : base(repository)
        {
        }
    }
}
