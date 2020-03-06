using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Extensions;
using Abp.ObjectMapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Text.RegularExpressions;

namespace Pensees.CargoX.Common
{
    public class QueryHelper<TEntity, TPrimaryKey, TEntityDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
    {
        private static Regex REGEX_COMMON_FIELDS = new Regex("((?:MaxNumRecordReturn|PageRecordNum|RecordStartNo|Sort)=)");
        private static MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<TEntity, TEntityDto>());
        private static IMapper ObjectMapper = new Mapper(config); 

        public static string GetQueryStringAndPagingParameters(string query, PagedAndSortedResultRequestDto input)
        {
            var list = query.Split("&");
            string qString = "";
            string maxNumRecordReturn = "";
            string pageRecordNum = "";
            string recordStartNo = "";
            string sort = "";
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
                        qString += (string.IsNullOrEmpty(qString) ? "" : "&") + item;
                        break;
                }
            }
            var pagedInput = input as IPagedAndSortedResultRequest;
            if (pagedInput != null)
            {
                pagedInput.Sorting = sort;

                int max;
                if (int.TryParse(maxNumRecordReturn, out max))
                {
                    pagedInput.MaxResultCount = max;
                }
                int skip;
                if (int.TryParse(recordStartNo, out skip))
                {
                    pagedInput.SkipCount = skip;
                }
            }
            return qString;
        }

        public static PagedResultDto<TEntityDto> PagingAndSorting(PagedAndSortedResultRequestDto input, IQueryable<TEntity> query)
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
        private static IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, PagedAndSortedResultRequestDto input)
        {
            if (!input.Sorting.IsNullOrEmpty())
            {
                return query.OrderBy(input.Sorting);
            }
            if (input.MaxResultCount>0)
            {
                return query.OrderByDescending(e => e.Id);
            }
            return query;
        }

        private static IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, PagedAndSortedResultRequestDto input)
        {
            return query.Skip(input.SkipCount).Take(input.MaxResultCount);
        }
        private static TEntityDto MapToEntityDto(TEntity entity)
        {
            return ObjectMapper.Map<TEntityDto>(entity);
        }
    }
}
