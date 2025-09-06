using AutoMapper;
using AuthTask1.Models;
using AuthTask1.Dto.Product;
using AuthTask1.Services;

namespace AuthTask1.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom<ImagePathResolver>())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CartItems, opt => opt.Ignore());
    }
}

