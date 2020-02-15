using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.Repository.Tollgates
{
    public interface ITollgateRepository : IRepository<Tollgate, long>
    {
        Task<List<Tollgate>> QueryByParams(Dictionary<string, string> parameters);
    }
}
