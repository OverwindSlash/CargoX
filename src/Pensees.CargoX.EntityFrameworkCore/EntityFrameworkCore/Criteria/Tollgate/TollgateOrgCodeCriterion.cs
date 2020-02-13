using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgateOrgCodeCriterion : ICriterion<Tollgate>
    {
        private readonly string _orgCode;

        public TollgateOrgCodeCriterion(string orgCode)
        {
            _orgCode = orgCode;
        }

        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.OrgCode == _orgCode);
        }
    }
}
