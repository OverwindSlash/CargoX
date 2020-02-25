using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class ShotTimeCriterion:ICriterion<Face>
    {
        private readonly Dictionary<string, string> _conditions;
        public ShotTimeCriterion(Dictionary<string, string> conditions)
        {
            _conditions = conditions;
        }
        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            foreach (var condition in _conditions)
            {
                switch (condition.Key)
                {
                    case "=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime == Convert.ToDateTime(condition.Value)));
                        break;
                    case ">":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime > Convert.ToDateTime(condition.Value)));
                        break;
                    case "<":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime < Convert.ToDateTime(condition.Value)));
                        break;
                    case ">=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime >= Convert.ToDateTime(condition.Value)));
                        break;
                    case "<=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime <= Convert.ToDateTime(condition.Value)));
                        break;
                    case "<>":
                    case "!=":
                        queryable = queryable.Where(p => p.SubImageInfos.Any(q => q.ShotTime != Convert.ToDateTime(condition.Value)));
                        break;

                    default:
                        break;
                }

            }

            return queryable;
        }
    }
}
