using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class OrCriterion<T> : ICriterion<T>
    {
        private readonly ICriterion<T> _left;
        private readonly ICriterion<T> _right;

        public OrCriterion(ICriterion<T> left, ICriterion<T> right)
        {
            _left = left;
            _right = right;
        }

        public IQueryable<T> HandleQueryable(IQueryable<T> query)
        {
            //warning: does not work
            var exp= Expression.OrElse(_left.HandleQueryable(query).Expression,
                _right.HandleQueryable(query).Expression);
            return query.Provider.CreateQuery<T>(exp);

        }
    }
}
