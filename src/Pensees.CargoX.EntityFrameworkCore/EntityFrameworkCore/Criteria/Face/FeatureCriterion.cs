using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class FeatureCriterion : ICriterion<Face>
    {
        private readonly List<byte> _feature;

        public FeatureCriterion(List<byte> feature)
        {
            _feature = feature;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            return queryable.Where(face => face.Feature.SequenceEqual(_feature));
        }
    }
}
