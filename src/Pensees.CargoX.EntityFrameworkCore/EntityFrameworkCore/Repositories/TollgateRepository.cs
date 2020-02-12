using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.Tollgates;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class TollgateRepository : CargoXRepositoryBase<Tollgate, long>, ITollgateRepository
    {
        public TollgateRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Tollgate>> GetTollgateByParams(Dictionary<string, string> parameters)
        {
            IQueryable<Tollgate> tollgatesqQueryable = GetQueryable();

            List<ICriterion<Tollgate>> criteria = ConvertToCriteria(parameters);
            foreach (var criterion in criteria)
            {
                tollgatesqQueryable = criterion.HandleQueryable(tollgatesqQueryable);
            }

            return tollgatesqQueryable.ToList();
        }

        private List<ICriterion<Tollgate>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            List<ICriterion<Tollgate>> queryCriteria = new List<ICriterion<Tollgate>>();

            foreach (var param in parameters)
            {
                switch (param.Key.ToLower())
                {
                    case "name":
                        queryCriteria.Add(new TollgateNameCriterion(param.Value));
                        break;
                    default:
                        break;

                }
            }

            return queryCriteria;
        }
    }
}
