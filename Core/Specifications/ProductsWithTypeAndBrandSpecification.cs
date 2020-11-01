using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypeAndBrandSpecification()
        {
            AddInclude(x =>x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }


} 