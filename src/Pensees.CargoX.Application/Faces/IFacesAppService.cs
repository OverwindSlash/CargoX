﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.Common;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Faces.Dto;

namespace Pensees.CargoX.Faces
{
    public interface IFacesAppService : IApplicationService
    {
        Task<PagedResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(PagedAndSortedRequestDto input);
        Task<PagedResultDto<FaceDto>> QueryClusteringFaceWithContition(string condition);
        //Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(Dictionary<string, string> parameters);
    }
}
