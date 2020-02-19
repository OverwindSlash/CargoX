using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class FaceIdCriterion : ICriterion<Face>
    {
        private readonly string _faceId;

        public FaceIdCriterion(string faceId)
        {
            _faceId = faceId;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            return queryable.Where(face => face.FaceId == _faceId);
        }
    }
}
