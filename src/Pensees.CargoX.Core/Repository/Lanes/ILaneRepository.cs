using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.Repository.Lanes
{
    public interface ILaneRepository : IRepository<Lane, long>
    {
        Task<List<Lane>> QueryByParams(Dictionary<string, string> parameters);
    }
}
