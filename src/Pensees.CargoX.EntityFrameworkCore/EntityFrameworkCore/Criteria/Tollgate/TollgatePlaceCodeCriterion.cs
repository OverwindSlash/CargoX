using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class TollgatePlaceCodeCriterion : ICriterion<Tollgate>
    {
        private readonly string _placeCode;

        public TollgatePlaceCodeCriterion(string placeCode)
        {
            _placeCode = placeCode;
        }

        public IQueryable<Tollgate> HandleQueryable(IQueryable<Tollgate> queryable)
        {
            return queryable.Where(tollgate => tollgate.PlaceCode == _placeCode);
        }
    }
}
