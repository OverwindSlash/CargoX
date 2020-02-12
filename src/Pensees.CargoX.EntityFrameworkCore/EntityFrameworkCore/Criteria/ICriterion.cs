using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pensees.CargoX.Entities;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public interface ICriterion<T>
    {
        IQueryable<T> HandleQueryable(IQueryable<T> queryable);
    }
}
