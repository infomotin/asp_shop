using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    //this class is design for output api data sender and views auto [+] mapper nuget pakge 
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductToReturnDto>()
            //the first perametter are destinations based on ProductToReturnDto on destinationMember , and second paramitter are s on Product Propertices
            //using Generic Expresstions  
            .ForMember(d =>d.ProductBrand, o => o.MapFrom(s =>s.ProductBrand.Name))
            .ForMember(d =>d.ProductType, o => o.MapFrom(s =>s.ProductType.Name));

        }
    }
}