﻿using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.Repository.Faces
{
    public interface IFaceRepository : IRepository<Face,long>
    {
        Task<List<Face>> QueryByParams(Dictionary<string, string> parameters);
        Task<List<Face>> QueryByParams(Dictionary<string, Dictionary<string, string>> parameters, IQueryable<Face> query);
    }
}
