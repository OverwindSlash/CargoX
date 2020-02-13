using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgatePlaceCriterion : ICriterion<Tollgate>
    {
        private readonly string _place;

        public TollgatePlaceCriterion(string place)
        {
            _place = place;
        }

        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.Place.Contains(_place));
        }
    }
}
