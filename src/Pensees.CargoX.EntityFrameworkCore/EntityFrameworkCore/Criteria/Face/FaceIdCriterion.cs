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
        private readonly UserCondition _condition;
        public FaceIdCriterion(string faceId)
        {
            _faceId = faceId;
        }

        public FaceIdCriterion(Dictionary<string, string> conditions)
        {
            _conditions = conditions;
        }
        public FaceIdCriterion(UserCondition condition)
        {
            _condition = condition;
        }
        public IQueryable<Face> HandleQueryable(IQueryable<Face> queryable)
        {
            switch (_condition?.Operator?.ToLower())
            {
                case "like":
                    queryable = queryable.Where(p => p.FaceId.Contains(_condition.Value));
                    break;
                case "=":
                    queryable = queryable.Where(p => p.FaceId == _condition.Value);
                    break;
                case "!=":
                case "<>":
                    queryable = queryable.Where(p => p.FaceId != _condition.Value);
                    break;
                default:
                    break;
            }
            if (_conditions == null)
            {
                return queryable;
            }
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
