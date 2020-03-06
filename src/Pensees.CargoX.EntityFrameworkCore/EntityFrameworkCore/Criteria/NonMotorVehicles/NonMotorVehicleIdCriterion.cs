using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class NonMotorVehicleIdCriterion : BaseCriterion<NonMotor>
    {
        public NonMotorVehicleIdCriterion(UserCondition condition) : base(condition)
        {
        }

        public override IQueryable<NonMotor> HandleQueryable(IQueryable<NonMotor> queryable)
        {
            switch (Condition?.Operator?.ToLower())
            {
                case "like":
                    queryable = queryable.Where(p => p.NonMotorVehicleID.Contains(Condition.Value));
                    break;
                case "=":
                    queryable = queryable.Where(p => p.NonMotorVehicleID == Condition.Value);
                    break;
                case "!=":
                case "<>":
                    queryable = queryable.Where(p => p.NonMotorVehicleID != Condition.Value);
                    break;
                default:
                    break;
            }
            return queryable;
        }
    }
}
