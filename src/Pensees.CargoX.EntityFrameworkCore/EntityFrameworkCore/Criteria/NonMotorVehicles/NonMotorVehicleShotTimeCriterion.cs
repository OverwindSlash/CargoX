using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class NonMotorVehicleShotTimeCriterion : BaseCriterion<NonMotor>
    {
        public NonMotorVehicleShotTimeCriterion(UserCondition condition) : base(condition)
        {
        }

        public override IQueryable<NonMotor> HandleQueryable(IQueryable<NonMotor> queryable)
        {
            switch (Condition?.Operator)
            {
                case "=":
                    queryable.Where(p => p.ShotTime == Convert.ToDateTime(Condition.Value));
                    break;
                case ">":
                    queryable.Where(p => p.ShotTime > Convert.ToDateTime(Condition.Value));
                    break;
                case "<":
                    queryable.Where(p => p.ShotTime < Convert.ToDateTime(Condition.Value));
                    break;
                case ">=":
                case "!<":
                    queryable.Where(p => p.ShotTime >= Convert.ToDateTime(Condition.Value));
                    break;
                case "<=":
                case "!>":
                    queryable.Where(p => p.ShotTime <= Convert.ToDateTime(Condition.Value));
                    break;
                case "!=":
                case "<>":
                    queryable.Where(p => p.ShotTime != Convert.ToDateTime(Condition.Value));
                    break;
                default:
                    break;
            }
            return queryable;
        }
    }
}
