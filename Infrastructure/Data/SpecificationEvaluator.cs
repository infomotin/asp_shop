using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQueryable(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec){
            var query = inputQuery;
            if(spec.Criteria !=null){
                query = query.Where(spec.Criteria); // in excutions p => p.ProductTypeId == id (lamda expression )
            }
            // to be as like same Working With this fun .Include(p =>p.ProductBrand)
            //.Include(p =>p.ProductType)
            //?????
            // Aggregate Query one or more query on ISpecifications class   
            // this is {current} is  DATABASE instance  [Include] is dotnet freamework fun 



            query = spec.Includes.Aggregate(query,(current, include) => current.Include(include));
            return query;
        }
    }
}