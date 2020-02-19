using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class SourceIdCriterion : ICriterion<Face>
    {
        private readonly string _sourceId;

        public SourceIdCriterion(string sourceId)
        {
            _sourceId = sourceId;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            return queryable.Where(face => face.SourceId == _sourceId);
        }
    }
}
