using System;
using System.Collections.Generic;
using System.Text;

namespace Pensees.CargoX.EntityFrameworkCore.Criteria
{
    public class ExpressionTreeNode<T>
    {
        public string Query { get; set; }
        public string LogicalOperator { get; set; }
        public ICriterion<T> Data { get; set; }
        public ExpressionTreeNode<T> Left { get; set; }
        public ExpressionTreeNode<T> Right { get; set; }
    }
}
