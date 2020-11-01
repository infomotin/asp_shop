using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecifications<T> 
    {
         //this is generic repository anti patten 

        //  Sentext :Exprations <Func<T,bool>Query>>

        Expression<Func<T,bool>> Criteria {get;}
        List<Expression<Func<T,object>>> Includes{get;}
    }
}