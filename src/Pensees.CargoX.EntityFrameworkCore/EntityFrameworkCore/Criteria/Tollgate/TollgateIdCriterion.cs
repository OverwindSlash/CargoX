using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgateIdCriterion : ICriterion<Tollgate>
    {
        private readonly string _tollgateId;

        public TollgateIdCriterion(string tollgateId)
        {
            _tollgateId = tollgateId;
        }

        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.TollgateId == _tollgateId);
        }
    }
}
