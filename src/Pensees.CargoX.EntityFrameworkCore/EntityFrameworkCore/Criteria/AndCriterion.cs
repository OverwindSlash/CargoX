using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class AndCriterion<T> : ICriterion<T>
    {
        private readonly ICriterion<T> _left;
        private readonly ICriterion<T> _right;

        public AndCriterion(ICriterion<T> left, ICriterion<T> right)
        {
            _left = left;
            _right = right;
        }

        //public Expression HandleExpression(ParameterExpression pe)
        //{
        //    return Expression.AndAlso(_left.HandleExpression(pe),
        //        _right.HandleExpression(pe));
        //}

        public IQueryable<T> HandleQueryable(IQueryable<T> query)
        {
            query = _left?.HandleQueryable(query);
            query = _right?.HandleQueryable(query);
            
            //if (left!=null && right !=null)
            //{
            //    return left.Intersect(right);
            //}
            return query;
        }
    }
}
