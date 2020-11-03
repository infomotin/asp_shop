using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Core.Specifications;
using API.Dtos;
using AutoMapper;


// ApiController  ProductsController : BaseApiController : ControllerBase inherited in serige [extends]
// another BuggyController : BaseApiController inherited in serige 
// ErrorController : BaseApiController 





namespace API.Controllers
{
    // For Implemiting with BaseApiController 
    // [ApiController]
    // [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {


        // private readonly StoreContext _context;
        // private readonly IProductRepository _repository;
        // public ProductsController(IProductRepository repository){
        //     // _repository = repository; 
        // }
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _ProductBrandRepo;
        private readonly IGenericRepository<ProductType> _ProductTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                    IGenericRepository<ProductBrand> ProductBrandRepo,
                                    IGenericRepository<ProductType> ProductTypeRepo, IMapper mapper)
        {
            
            _productsRepo = productsRepo;
            _ProductBrandRepo = ProductBrandRepo;
            _ProductTypeRepo = ProductTypeRepo;
            _mapper = mapper;
        }


        // Sync Method 
        // public ActionResult<List<Product>> GetProducts(){
        //     var products = _context.Products.ToList();
        //     return Ok(products);   
        // }


        // async Version 

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            //implements IGeneric Class method using on this ends point 
            // var products =await _productsRepo.ListAllAsync();
            //caling Product witht type and Brand Class  for pussing This type Working 
            var spec = new ProductsWithTypeAndBrandSpecification();

            var products = await _productsRepo.ListAsync(spec);
            //all return data are save in current context at the memory address at [products] then 
            //slelect one product and rearange this data with productretundto class finaly retun a list 
            // return products.Select(product => new ProductToReturnDto
            // {
            //     Id = product.id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // }).ToList();
            // return Ok(products);   

            // in the Map{first part orginal result[db part] , convartede result what we want to see Based on design class}
            return Ok(_mapper
                        .Map< IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }




        [HttpGet("{id}")]
        //Lecture 40 are goods Descriptions 
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {

            var spec = new ProductsWithTypeAndBrandSpecification(id);


            // return await _productsRepo.GetEntitiyWithSpac(spec);
            var product = await _productsRepo.GetEntitiyWithSpac(spec);
            //[peoduct] is mamory and its mapping with helping mapping calss with based on ProductToDoi class 
            return _mapper.Map<Product,ProductToReturnDto>(product);
            // return new ProductToReturnDto
            // {
            //     Id = product.id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     Price = product.Price,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name


            // };
        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _ProductBrandRepo.ListAllAsync());
        }


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _ProductTypeRepo.ListAllAsync());
        }
    }
}