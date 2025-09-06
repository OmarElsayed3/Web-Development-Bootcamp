using AutoMapper;
using AuthTask1.Models;
using AuthTask1.Dto.Cart;

namespace AuthTask1.Mapper;

public class CartMapper : Profile
{
    public CartMapper()
    {
        CreateMap<Cart, CartDto>()
            .ForMember(dest => dest.UName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems));
        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
    }
}

