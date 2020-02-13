using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgateStatusCriterion : ICriterion<Tollgate>
    {
        private readonly string _status;

        public TollgateStatusCriterion(string status)
        {
            if (status.Length == 1)
            {
                _status = status;
            }
            else
            {
                _status = "x";
            }
        }

        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.Status == _status);
        }
    }
}
