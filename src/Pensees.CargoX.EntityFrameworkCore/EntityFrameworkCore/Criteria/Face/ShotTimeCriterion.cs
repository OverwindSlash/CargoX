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
        private readonly UserCondition _condition;
        public ShotTimeCriterion(Dictionary<string, string> conditions)
        {
            _conditions = conditions;
        }

        public ShotTimeCriterion(UserCondition condition)
        {
            _condition = condition;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            switch (_condition?.Operator)
            {
                case "=":
                    queryable.Where(p => p.ShotTime == Convert.ToDateTime(_condition.Value));
                    break;
                case ">":
                    queryable.Where(p => p.ShotTime > Convert.ToDateTime(_condition.Value));
                    break;
                case "<":
                    queryable.Where(p => p.ShotTime < Convert.ToDateTime(_condition.Value));
                    break;
                case ">=":
                case "!<":
                    queryable.Where(p => p.ShotTime >= Convert.ToDateTime(_condition.Value));
                    break;
                case "<=":
                case "!>":
                    queryable.Where(p => p.ShotTime <= Convert.ToDateTime(_condition.Value));
                    break;
                case "!=":
                case "<>":
                    queryable.Where(p => p.ShotTime != Convert.ToDateTime(_condition.Value));
                    break;
                default:
                    break;
            }
            if (_conditions==null)
            {
                return queryable;
            }
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
