using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class InfoKindCriterion : ICriterion<Face>
    {
        private readonly int _infoKind;

        public InfoKindCriterion(int infoKind)
        {
            _infoKind = infoKind;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            return queryable.Where(face => face.InfoKind == _infoKind);
        }
    }
}
