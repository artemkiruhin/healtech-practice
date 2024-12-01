using AutoMapper;
using MauiApp1.DbApp.Models;
using MauiApp1.DbApp.Models.Dtos;

namespace MauiApp1.Front.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product Mapping
            CreateMap<ProductEntity, ProductDto>().ReverseMap();

            // Order Mapping
            CreateMap<OrderEntity, OrderDto>()
                .ForMember(dest => dest.TotalPrice,
                    opt => opt.MapFrom(src => src.Quantity * src.Product.Price));

            CreateMap<OrderDto, OrderEntity>()
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore());

            // User Mapping
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
