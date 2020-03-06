using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore
{
    public class MotorVehicleIdCriterion : BaseCriterion<Motor>
    {
        public MotorVehicleIdCriterion(UserCondition condition) : base(condition)
        {
        }

        public override IQueryable<Motor> HandleQueryable(IQueryable<Motor> queryable)
        {
            switch (Condition?.Operator?.ToLower())
            {
                case "like":
                    queryable = queryable.Where(p => p.MotorVehicleID.Contains(Condition.Value));
                    break;
                case "=":
                    queryable = queryable.Where(p => p.MotorVehicleID == Condition.Value);
                    break;
                case "!=":
                case "<>":
                    queryable = queryable.Where(p => p.MotorVehicleID != Condition.Value);
                    break;
                default:
                    break;
            }
            return queryable;
        }
    }
}
