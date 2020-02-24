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
        private readonly Dictionary<string, string> _conditions;
        public FaceIdCriterion(string faceId)
        {
            _faceId = faceId;
        }

        public FaceIdCriterion(Dictionary<string, string> conditions)
        {
            _conditions = conditions;
        }

        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            foreach (var condition in _conditions)
            {
                switch (condition.Key)
                {
                    case "=":
                        queryable = queryable.Where(p => p.FaceId == condition.Value);
                        break;
                    case "<>":
                        queryable = queryable.Where(p => p.FaceId != condition.Value);
                        break;
                    default:
                        break;
                }

            }

            return queryable;
        }
    }
}
