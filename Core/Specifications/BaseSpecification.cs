using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;}= 
            new List<Expression<Func<T, object>>>();
        protected void AddInclude(Expression<Func<T, object>> includeExpression){
            Includes.Add(includeExpression);
        }
    }

}  