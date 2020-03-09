using Abp.Domain.Repositories;
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
        Task<IQueryable<Face>> QueryByParams(Dictionary<string, Dictionary<string, string>> parameters, IQueryable<Face> query);
        Task<IQueryable<Face>> QueryByConditions(string queryString,IQueryable<Face> query);
    }
}
