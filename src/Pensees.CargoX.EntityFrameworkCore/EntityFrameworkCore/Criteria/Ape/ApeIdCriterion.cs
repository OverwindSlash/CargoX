using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class ApeIdCriterion : BaseCriterion<Ape>
    {
        public ApeIdCriterion(UserCondition condition) : base(condition)
        {
        }

        public override IQueryable<Ape> HandleQueryable(IQueryable<Ape> queryable)
        {
            switch (Condition?.Operator?.ToLower())
            {
                case "like":
                    queryable = queryable.Where(p => p.ApeID.Contains(Condition.Value));
                    break;
                case "=":
                    queryable = queryable.Where(p => p.ApeID == Condition.Value);
                    break;
                case "!=":
                case "<>":
                    queryable = queryable.Where(p => p.ApeID != Condition.Value);
                    break;
                default:
                    break;
            }
            return queryable;
        }
    }
}
