using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgateCat2Criterion : ICriterion<Tollgate>
    {
        private readonly int _category2;

        public TollgateCat2Criterion(int category2)
        {
            _category2 = category2;
        }

        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.TollgateCat2 == _category2);
        }
    }
}
