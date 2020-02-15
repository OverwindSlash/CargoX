using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.Lanes;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class LaneRepository : CargoXRepositoryBase<Lane, long>, ILaneRepository
    {
        public LaneRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        protected override List<ICriterion<Lane>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            List<ICriterion<Lane>> queryCriteria = new List<ICriterion<Lane>>();

            foreach (var param in parameters)
            {
                switch (param.Key.ToLower())
                {
                    case "tollgateid":
                        queryCriteria.Add(new LaneTollgateIdCriterion(param.Value));
                        break;
                    
                    default:
                        break;
                }
            }

            return queryCriteria;
        }
    }
}
