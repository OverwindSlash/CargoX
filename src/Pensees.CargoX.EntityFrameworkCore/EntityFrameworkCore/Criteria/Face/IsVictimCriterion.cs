using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class IsVictimCriterion : ICriterion<Face>
    {
        private readonly int _isVictim;

        public IsVictimCriterion(int isVictim)
        {
            _isVictim = isVictim;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            return queryable.Where(face => face.IsVictim == _isVictim);
        }
    }
}
