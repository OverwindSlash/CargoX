using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public abstract class BaseCriterion<T> : ICriterion<T>
    {
        protected UserCondition Condition { get; private set; }

        protected BaseCriterion(UserCondition condition)
        {
            Condition = condition;
        }

        public abstract IQueryable<T> HandleQueryable(IQueryable<T> queryable);
    }
}
