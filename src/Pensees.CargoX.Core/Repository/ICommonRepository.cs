using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pensees.CargoX.Repository
{
    public interface ICommonRepository<TEntity,TPrimaryKey>: IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<IQueryable<TEntity>> QueryByConditions(string queryString);

    }
}
