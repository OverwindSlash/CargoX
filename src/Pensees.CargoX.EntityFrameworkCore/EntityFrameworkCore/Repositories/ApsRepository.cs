using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.Apss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class ApsRepository : CargoXRepositoryBase<Aps, long>, IApsRepository
    {
        public ApsRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        protected override List<ICriterion<Aps>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        protected override List<ICriterion<Aps>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters)
        {
            throw new NotImplementedException();
        }

        protected override ICriterion<Aps> GetCriterion(UserCondition cond)
        {
            ICriterion<Aps> criterion = null;
            switch (cond.Key.ToLower())
            {
                case "apsid":
                    criterion = new ApsIdCriterion(cond) as ICriterion<Aps>;
                    break;
                default:
                    break;
            }
            return criterion;
        }
    }
}
