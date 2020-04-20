using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.Subscribes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class SubscribeRepository : CargoXRepositoryBase<Subscribe, long>, ISubscribeRepository
    {
        public SubscribeRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        protected override List<ICriterion<Subscribe>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        protected override List<ICriterion<Subscribe>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters)
        {
            throw new NotImplementedException();
        }

        protected override ICriterion<Subscribe> GetCriterion(UserCondition cond)
        {
            throw new NotImplementedException();
        }
    }
}
