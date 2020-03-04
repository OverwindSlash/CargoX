using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private static string AND = "AND";
        private static string AND_OR = "AND|OR";
        private static Regex REGEX_AND = new Regex("&");
        private static Regex REGEX_AND_OR = new Regex("AND|OR");
        private static Regex REGEX_OPERATOR = new Regex("(=|>(?:=){0,1}|<(?:=|>)?|(<>)|!=|!<|!>)|(LIKE)");
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

        public async Task<IQueryable<TEntity>> QueryByParams(Dictionary<string, Dictionary<string,string>> parameters, IQueryable<TEntity> queryable)
        {
            if (queryable==null)
            {
                queryable = GetQueryable();
            }
            List<ICriterion<TEntity>> criteria = ConvertToCriteria(parameters);
            foreach (var criterion in criteria)
            {
                queryable = criterion.HandleQueryable(queryable);
            }

            return queryable;
        }

        protected abstract List<ICriterion<TEntity>> ConvertToCriteria(Dictionary<string, string> parameters);
        protected abstract List<ICriterion<TEntity>> ConvertToCriteria(Dictionary<string, Dictionary<string, string>> parameters);

        //query string interpretor
        public async Task<IQueryable<TEntity>> QueryByConditions(string queryString)
        {
            queryString = queryString.Replace(" ", "");
            var query = GetQueryable();
            if (!string.IsNullOrEmpty(queryString))
            {
                var head = new ExpressionTreeNode<TEntity> { Query = queryString };
                CreateTree(head);
                query=head.Data.HandleQueryable(query);
            }
            return query;
        }
        public void CreateTree(ExpressionTreeNode<TEntity> node)
        {
            string logic = AND;
            node.Query = REGEX_AND.Replace(node.Query, "#", 1, 0);
            var list = node.Query.Split("#");
            if (list.Length == 1)
            {
                int endAt = 0;
                if (list[0][0] == '(')
                {
                    node.Query = list[0].Substring(1, list[0].Length - 2);
                    IsValid(node.Query, out endAt);
                }
                logic = Regex.Match(node.Query.Substring(endAt, node.Query.Length - 1 - endAt), AND_OR).Value;
                node.Query = REGEX_AND_OR.Replace(node.Query, "#", 1, endAt);
                list = node.Query.Split("#");
                if (list.Length == 1)
                {
                    var data = REGEX_OPERATOR.Split(node.Query);
                    var cond = new UserCondition { Key = data[0], Value = data[2], Operator = data[1] };
                    node.Data = GetCriterion(cond);
                    return;
                }
            }
            node.LogicalOperator = logic;
            var left = new ExpressionTreeNode<TEntity>() { Query = list[0] };
            node.Left = left;
            CreateTree(node.Left);
            var right = new ExpressionTreeNode<TEntity>() { Query = list[1] };
            node.Right = right;
            CreateTree(node.Right);
            if (node.LogicalOperator == "AND")
            {
                node.Data = new AndCriterion<TEntity>(left.Data, right.Data);
            }
            else
            {
                node.Data = new OrCriterion<TEntity>(left.Data, right.Data);
            }
        }

        protected abstract ICriterion<TEntity> GetCriterion(UserCondition cond);
        private bool IsValid(string query, out int endAt)
        {
            endAt = 0;
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < query.Length; i++)
            {
                if (query[i] == '(')
                {
                    stack.Push(query[i]);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        endAt = i == 0 ? 0 : i - 1;
                        return false;
                    }
                    if (query[i] == ')' && stack.Pop() != '(')
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
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
