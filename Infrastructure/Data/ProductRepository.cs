using Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class ProductRepository:IProductRepository
    {
        //this is for Data Base Tabale Interface 
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context){
            _context = context;
        }

        //using database table interface to controller data CRUD 
        public async Task<Product> GetProductByIdAsync(int id){
            return await _context.Products
            .Include(p =>p.ProductBrand)
            .Include(p =>p.ProductType)
            .FirstOrDefaultAsync(p =>p.id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync(){
            return await _context.Products
            .Include(p =>p.ProductBrand)
            .Include(p =>p.ProductType)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetTypesAsync()
        {
            return await _context.ProductType.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetBrandsAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }

    }
}