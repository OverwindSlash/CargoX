using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.Apes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class ApeRepository : CargoXRepositoryBase<Ape, long>, IApeRepository
    {
        public ApeRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        protected override List<ICriterion<Ape>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        protected override List<ICriterion<Ape>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters)
        {
            throw new NotImplementedException();
        }

        protected override ICriterion<Ape> GetCriterion(UserCondition cond)
        {
            ICriterion<Ape> criterion = null;
            switch (cond.Key.ToLower())
            {
                case "apeid":
                    criterion = new ApeIdCriterion(cond) as ICriterion<Ape>;
                    break;
                default:
                    break;
            }
            return criterion;
        }
    }
}
