using AutoMapper;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Service.DTOs.Products;

namespace OnlineMarket.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductCreationDto>().ReverseMap();
        }
    }
}
