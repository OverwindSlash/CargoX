using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System.Linq;

namespace Pensees.CargoX
{
    public abstract class CargoXAsyncCrudAppService<TEntity, TEntityDto>
       : CargoXAsyncCrudAppService<TEntity, TEntityDto, int>
           where TEntity : class, IEntity<int>
           where TEntityDto : IEntityDto<int>
    {
        protected CargoXAsyncCrudAppService(IRepository<TEntity, int> repository) : base(repository)
        {
        }
    }
    public abstract class CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput>
       : CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto, TEntityDto>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected CargoXAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }
    public abstract class CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey>
       : CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected CargoXAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }
    public abstract class CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput>
       : CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TCreateInput>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TCreateInput : IEntityDto<TPrimaryKey>
    {
        protected CargoXAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }
    public abstract class CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
       : CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        protected CargoXAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }
    public abstract class CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput>
       : CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
           where TGetInput : IEntityDto<TPrimaryKey>
    {
        protected CargoXAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }

    public abstract class CargoXAsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
       : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
           where TEntity : class, IEntity<TPrimaryKey>
           where TEntityDto : IEntityDto<TPrimaryKey>
           where TUpdateInput : IEntityDto<TPrimaryKey>
           where TGetInput : IEntityDto<TPrimaryKey>
           where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        protected CargoXAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }

        public virtual PagedResultDto<TEntityDto> PagingAndSorting(TGetAllInput input, IQueryable<TEntity> query)
        {
            var totalCount = query.Count();

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = query.ToList();

            return new PagedResultDto<TEntityDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
    }
}
