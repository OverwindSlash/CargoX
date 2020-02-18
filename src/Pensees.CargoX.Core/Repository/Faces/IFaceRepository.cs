using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.Repository.Faces
{
    public interface IFaceRepository : IRepository<Face,long>
    {
        Task<List<Face>> QueryByParams(Dictionary<string, string> parameters);
    }
}
