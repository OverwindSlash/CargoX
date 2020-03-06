using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class ApsIdCriterion : BaseCriterion<Aps>
    {
        public ApsIdCriterion(UserCondition condition) : base(condition)
        {
        }

        public override IQueryable<Aps> HandleQueryable(IQueryable<Aps> queryable)
        {
            switch (Condition?.Operator?.ToLower())
            {
                case "like":
                    queryable = queryable.Where(p => p.ApsID.Contains(Condition.Value));
                    break;
                case "=":
                    queryable = queryable.Where(p => p.ApsID == Condition.Value);
                    break;
                case "!=":
                case "<>":
                    queryable = queryable.Where(p => p.ApsID != Condition.Value);
                    break;
                default:
                    break;
            }
            return queryable;
        }
    }
}
