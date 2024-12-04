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
    .ForMember(dest => dest.CustomerUsername,
        opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Username : "Unknown")) // Для отладки
    .ForMember(dest => dest.ProductName,
        opt => opt.MapFrom(src => src.Product.Name))
    .ForMember(dest => dest.TotalPrice,
        opt => opt.MapFrom(src => src.TotalPrice));

            CreateMap<OrderDto, OrderEntity>()
                .ForMember(dest => dest.Product, opt => opt.Ignore()) // Игнорируем навигационные свойства
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore()); // TotalPrice задаётся в сущности автоматически

            // User Mapping
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
