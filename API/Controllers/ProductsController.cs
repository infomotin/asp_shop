using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        

        // private readonly StoreContext _context;
        // private readonly IProductRepository _repository;
        // public ProductsController(IProductRepository repository){
        //     // _repository = repository; 
        // }
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _ProductBrandRepo;
        private readonly IGenericRepository<ProductType> _ProductTypeRepo;

        public ProductsController (IGenericRepository<Product> productsRepo, 
                                    IGenericRepository<ProductBrand> ProductBrandRepo, 
                                    IGenericRepository<ProductType>  ProductTypeRepo){
            _productsRepo = productsRepo;
            _ProductBrandRepo = ProductBrandRepo;
            _ProductTypeRepo = ProductTypeRepo;
        }


        // Sync Method 
        // public ActionResult<List<Product>> GetProducts(){
        //     var products = _context.Products.ToList();
        //     return Ok(products);   
        // }


        // async Version 
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            //implements IGeneric Class method using on this ends point
            // var products =await _productsRepo.ListAllAsync();
            //caling Product witht type and Brand Class  for pussing This type Working 
            var spec = new ProductsWithTypeAndBrandSpecification();

            var products =await _productsRepo.ListAsync(spec);
            return Ok(products);   
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id){   
            return await _productsRepo.GetByIdAsync(id);
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() {
            return Ok(await _ProductBrandRepo.ListAllAsync());
        }


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() {
            return Ok(await _ProductTypeRepo.ListAllAsync());
        }
    }
}