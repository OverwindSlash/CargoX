using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgateNameCriterion : ICriterion<Tollgate>
    {
        private readonly string _name;

        public TollgateNameCriterion(string name)
        {
            _name = name;
        }
        
        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.Name == _name);
        }
    }
}
