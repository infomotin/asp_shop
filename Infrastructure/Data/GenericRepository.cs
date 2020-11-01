using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        //db class interface 
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context)
        {
            _context = context;
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }



        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


//news adding this functins 

        public Task<T> GetEntitiyWithSpac(ISpecifications<T> spec)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec)
        {
            throw new System.NotImplementedException();
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> spec){
            return SpecificationEvaluator<T>.GetQueryable(_context.Set<T>().AsQueryable(),spec);
    }
}