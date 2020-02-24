using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public static class QueryableExtension
    {
        public static IQueryable<TEntity> QueryByParams<TEntity>(this IQueryable<TEntity> query, Dictionary<string, Dictionary<string, string>> parameters)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return query;
        }
    }
}
