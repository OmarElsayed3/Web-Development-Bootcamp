using AutoMapper;
using CleanArch.Application.Features.Carts.Dtos;
using CleanArch.Domain.Models.CartItems;

namespace CleanArch.Application.Mapping.Cart;

public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<CartItem, CartItemDto>().ReverseMap();
    }
}

