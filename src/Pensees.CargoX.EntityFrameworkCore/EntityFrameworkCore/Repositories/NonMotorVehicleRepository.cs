using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.NonMotorVehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class NonMotorVehicleRepository : CargoXRepositoryBase<NonMotor, long>, INonMotorVehicleRepository
    {
        public NonMotorVehicleRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        protected override List<ICriterion<NonMotor>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        protected override List<ICriterion<NonMotor>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters)
        {
            throw new NotImplementedException();
        }

        protected override ICriterion<NonMotor> GetCriterion(UserCondition cond)
        {
            ICriterion<NonMotor> criterion = null;
            switch (cond.Key.ToLower())
            {
                case "nonmotorvehicleid":
                    criterion = new NonMotorVehicleIdCriterion(cond) as ICriterion<NonMotor>;
                    break;
                case "shottime":
                    criterion = new NonMotorVehicleShotTimeCriterion(cond) as ICriterion<NonMotor>;
                    break;
                default:
                    break;
            }
            return criterion;
        }
    }
}
