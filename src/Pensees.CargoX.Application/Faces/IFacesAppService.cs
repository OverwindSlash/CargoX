using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.Common;
using Pensees.CargoX.Faces.Dto;

namespace Pensees.CargoX.Faces
{
    public interface IFacesAppService : IApplicationService
    {
        Task<PagedResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(PagedAndSortedRequestDto input);
        Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceWithContition(string condition);
        //Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(Dictionary<string, string> parameters);
    }
}
