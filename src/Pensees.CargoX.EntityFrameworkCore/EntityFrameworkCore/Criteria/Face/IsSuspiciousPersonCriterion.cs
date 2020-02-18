using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class IsSuspiciousPersonCriterion : ICriterion<Face>
    {
        private readonly int _isSuspiciousPerson;

        public IsSuspiciousPersonCriterion(int isSuspiciousPerson)
        {
            _isSuspiciousPerson = isSuspiciousPerson;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            return queryable.Where(face => face.IsSuspiciousPerson == _isSuspiciousPerson);
        }
    }
}
