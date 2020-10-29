using Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class ProductRepository:IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context){
            _context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id){
            return await _context.Products.FindAsync(id);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync(){
            return await _context.Products.ToListAsync();
        }
    }
}