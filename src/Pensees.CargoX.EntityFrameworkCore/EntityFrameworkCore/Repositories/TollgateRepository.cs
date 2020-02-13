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
                    case "id":
                        queryCriteria.Add(new TollgateIdCriterion(param.Value));
                        break;
                    case "name":
                        queryCriteria.Add(new TollgateNameCriterion(param.Value));
                        break;
                    case "placecode":
                        queryCriteria.Add(new TollgatePlaceCodeCriterion(param.Value));
                        break;
                    case "place":
                        queryCriteria.Add(new TollgatePlaceCriterion(param.Value));
                        break;
                    case "status":
                        queryCriteria.Add(new TollgateStatusCriterion(param.Value));
                        break;
                    case "cat":
                        queryCriteria.Add(new TollgateCatCriterion(param.Value));
                        break;
                    case "cat2":
                        bool result = Int32.TryParse(param.Value, out var intValue);
                        queryCriteria.Add(new TollgateCat2Criterion(intValue));
                        break;
                    case "orgcode":
                        queryCriteria.Add(new TollgateOrgCodeCriterion(param.Value));
                        break;
                    default:
                        break;
                }
            }

            return queryCriteria;
        }
    }
}
