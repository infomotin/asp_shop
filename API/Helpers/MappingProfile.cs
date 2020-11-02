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
            CreateMap<Product,ProductToReturnDto>();

        }
    }
}