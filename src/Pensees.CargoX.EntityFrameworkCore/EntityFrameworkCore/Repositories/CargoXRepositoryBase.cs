using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Pensees.CargoX.Entities;
using Pensees.CargoX.EntityFrameworkCore.Criteria;

namespace Pensees.CargoX.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class CargoXRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<CargoXDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CargoXRepositoryBase(IDbContextProvider<CargoXDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Add your common methods for all repositories
        public async Task<List<TEntity>> QueryByParams(Dictionary<string, string> parameters)
        {
            IQueryable<TEntity> queryable = GetQueryable();

            List<ICriterion<TEntity>> criteria = ConvertToCriteria(parameters);
            foreach (var criterion in criteria)
            {
                queryable = criterion.HandleQueryable(queryable);
            }

            return queryable.ToList();
        }

        public async Task<List<TEntity>> QueryByParams(Dictionary<string, Dictionary<string,string>> parameters)
        {
            IQueryable<TEntity> queryable = GetQueryable();

            List<ICriterion<TEntity>> criteria = ConvertToCriteria(parameters);
            foreach (var criterion in criteria)
            {
                queryable = criterion.HandleQueryable(queryable);
            }

            return queryable.ToList();
        }

        protected abstract List<ICriterion<TEntity>> ConvertToCriteria(Dictionary<string, string> parameters);
        protected abstract List<ICriterion<TEntity>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters);
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="CargoXRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class CargoXRepositoryBase<TEntity> : CargoXRepositoryBase<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        protected CargoXRepositoryBase(IDbContextProvider<CargoXDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Do not add any method here, add to the class above (since this inherits it)!!!
    }
}
