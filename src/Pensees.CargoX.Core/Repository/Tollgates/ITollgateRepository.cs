using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.Repository.Tollgates
{
    public interface ITollgateRepository : IRepository
    {
        List<Tollgate> GetTollgateByParams(Dictionary<string, string> parameters);
    }
}
