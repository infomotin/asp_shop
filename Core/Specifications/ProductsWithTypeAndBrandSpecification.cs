using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        //if there wase no peramitter 
        public ProductsWithTypeAndBrandSpecification()
        {
            AddInclude(x =>x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        //if Have paremitter 
        public ProductsWithTypeAndBrandSpecification(int id) : base(x =>x.id == id)
        {
            AddInclude(x =>x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }


} 