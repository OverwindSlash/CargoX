using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Pensees.CargoX.Common.Dto;
using Pensees.CargoX.Entities;
using Pensees.CargoX.Faces.Dto;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
        Regex REGEX_COMMON_FIELDS = new Regex("((?:MaxNumRecordReturn|PageRecordNum|RecordStartNo|Sort)=)");
        protected CargoXAsyncCrudAppService(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }

        protected PagedResultDto<TEntityDto> PagingAndSorting(TGetAllInput input, IQueryable<TEntity> query)
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
        protected string GetQueryStringAndPagingParameters(string query,TGetAllInput input)
        {
            var list = query.Split("&");
            string qString = "";
            string maxNumRecordReturn="";
            string pageRecordNum="";
            string recordStartNo="";
            string sort="";
            foreach (var item in list)
            {
                var s = item.Substring(1, item.Length - 2);
                var m = REGEX_COMMON_FIELDS.Match(s);
                var l = REGEX_COMMON_FIELDS.Split(s);
                switch (m.Value)
                {
                    case "MaxNumRecordReturn=":
                        maxNumRecordReturn = l[2];
                        break;
                    case "PageRecordNum=":
                        pageRecordNum = l[2];
                        break;
                    case "RecordStartNo=":
                        recordStartNo = l[2];
                        break;
                    case "Sort=":
                        sort = l[2];
                        break;
                    default:
                        qString += (string.IsNullOrEmpty(qString)?"": "&") + item;
                        break;
                }
            }
            var pagedInput = input as IPagedAndSortedResultRequest;
            if (pagedInput!=null)
            {
                pagedInput.Sorting = sort;

                int max;
                if (int.TryParse(maxNumRecordReturn,out max))
                {
                    pagedInput.MaxResultCount = max;
                }
                int skip;
                if (int.TryParse(recordStartNo,out skip))
                {
                    pagedInput.SkipCount = skip;
                }
            }
            return qString;
        }

        public virtual Task<ResponseStatusList> CreateList(CreateOrUpdateListInputDto<TEntityDto> input) 
        {
            return null;
        }
        public virtual Task<ResponseStatusList> UpdateList(CreateOrUpdateListInputDto<TEntityDto> input)
        {
            return null;
        }
        public virtual Task<ResponseStatusList> DeleteList(string input)
        {
            return null;
        }

    }
}
