using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class PersonRepository : CargoXRepositoryBase<Person, long>, IPersonRepository
    {
        public PersonRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        protected override List<ICriterion<Person>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters)
        {
            List<ICriterion<Person>> queryCriteria = new List<ICriterion<Person>>();
            if (parameters == null)
            {
                return queryCriteria;
            }
            foreach (var param in parameters)
            {
                switch (param.Key.ToLower())
                {
                    case "faceid":
                        queryCriteria.Add(new PersonIdCriterion(param.Value));
                        break;
                    case "shottime":
                        queryCriteria.Add(new PersonShotTimeCriterion(param.Value));
                        break;
                    default:
                        break;
                }
            }

            return queryCriteria;
        }

        protected override List<ICriterion<Person>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        protected override ICriterion<Person> GetCriterion(UserCondition cond)
        {
            throw new NotImplementedException();
        }
    }
}
