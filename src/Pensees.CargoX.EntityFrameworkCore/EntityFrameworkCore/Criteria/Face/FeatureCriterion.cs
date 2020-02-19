using Pensees.CargoX.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class FeatureCriterion : ICriterion<Face>
    {
        private readonly string _feature;

        public FeatureCriterion(string feature)
        {
            _feature = feature;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            //base64string to list<byte>
            var byteArray = Convert.FromBase64String(_feature);
            var byteList = byteArray.ToList();
            return queryable.Where(face => face.Feature.SequenceEqual(byteList));
        }
    }
}
