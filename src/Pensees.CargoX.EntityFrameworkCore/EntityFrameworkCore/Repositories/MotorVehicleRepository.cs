using Abp.EntityFrameworkCore;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;
using Pensees.CargoX.Repository.MotorVehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    public class MotorVehicleRepository : CargoXRepositoryBase<Motor, long>, IMotorVehicleRepository
    {
        public MotorVehicleRepository(IDbContextProvider<CargoXDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        protected override List<ICriterion<Motor>> ConvertToCriteria(Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        protected override List<ICriterion<Motor>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters)
        {
            throw new NotImplementedException();
        }

        protected override ICriterion<Motor> GetCriterion(UserCondition cond)
        {
            ICriterion<Motor> criterion = null;
            switch (cond.Key.ToLower())
            {
                case "motorvehicleid":
                    criterion = new MotorVehicleIdCriterion(cond) as ICriterion<Motor>;
                    break;
                case "shottime":
                    criterion = new MotorVehicleShotTimeCriterion(cond) as ICriterion<Motor>;
                    break;
                default:
                    break;
            }
            return criterion;
        }
    }
}
