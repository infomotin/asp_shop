using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> include {get;}= new List<Expression<Func<T, object>>>();
    }

}  