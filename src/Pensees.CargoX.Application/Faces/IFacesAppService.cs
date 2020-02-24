﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Pensees.CargoX.Faces.Dto;

namespace Pensees.CargoX.Faces
{
    public interface IFacesAppService : IApplicationService
    {
        Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(Dictionary<string, Dictionary<string, string>> parameters);
        ClusteringFaceDto TestQueryByParams(Dictionary<string, Dictionary<string,string>> parameters);
        //Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceByParams(Dictionary<string, string> parameters);

        Task<ListResultDto<ClusteringFaceDto>> QueryClusteringFaceWithContition(string condition);
    }
}