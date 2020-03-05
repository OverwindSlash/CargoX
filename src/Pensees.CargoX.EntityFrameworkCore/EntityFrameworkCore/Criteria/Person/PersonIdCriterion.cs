using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class PersonIdCriterion : ICriterion<Person>
    {
        private readonly Dictionary<string, string> _conditions;
        private readonly UserCondition _condition;

        public PersonIdCriterion(UserCondition condition)
        {
            _condition = condition;
        }

        public PersonIdCriterion(Dictionary<string, string> conditions)
        {
            _conditions = conditions;
        }

        public IQueryable<Person> HandleQueryable(IQueryable<Person> queryable)
        {
            switch (_condition?.Operator?.ToLower())
            {
                case "like":
                    queryable = queryable.Where(p => p.PersonID.Contains(_condition.Value));
                    break;
                case "=":
                    queryable = queryable.Where(p => p.PersonID == _condition.Value);
                    break;
                case "!=":
                case "<>":
                    queryable = queryable.Where(p => p.PersonID != _condition.Value);
                    break;
                default:
                    break;
            }
            if (_conditions == null)
            {
                return queryable;
            }
            foreach (var condition in _conditions)
            {
                switch (condition.Key)
                {
                    case "=":
                        queryable = queryable.Where(p => p.PersonID == condition.Value);
                        break;
                    case "<>":
                    case "!=":
                        queryable = queryable.Where(p => p.PersonID != condition.Value);
                        break;
                    default:
                        break;
                }
            }
            return queryable;
        }
    }
}
