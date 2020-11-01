using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria => throw new NotImplementedException();

        public List<Expression<Func<T, object>>> include => throw new NotImplementedException();
    }

}