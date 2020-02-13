using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgateCatCriterion : ICriterion<Tollgate>
    {
        private readonly string _category;

        public TollgateCatCriterion(string category)
        {
            _category = category;
        }

        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.TollgateCat == _category);
        }
    }
}
