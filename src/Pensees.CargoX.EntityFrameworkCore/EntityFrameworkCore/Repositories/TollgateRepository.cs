using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Repository.Tollgates;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class TollgateRepository : CargoXRepositoryBase<Tollgate, long>, ITollgateRepository
    {
        public TollgateRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<Tollgate> GetTollgateByParams(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
