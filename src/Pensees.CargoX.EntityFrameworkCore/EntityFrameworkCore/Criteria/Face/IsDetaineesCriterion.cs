using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class IsDetaineesCriterion : ICriterion<Face>
    {
        private readonly int _isDetainees;

        public IsDetaineesCriterion(int isDetainees)
        {
            _isDetainees = isDetainees;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            return queryable.Where(face => face.IsDetainees == _isDetainees);
        }
    }
}
