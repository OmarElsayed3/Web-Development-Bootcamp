using AutoMapper;
using CleanArch.Application.Features.Carts.Commands.Add;
using CleanArch.Application.Features.Carts.Dtos;

namespace CleanArch.Application.Mapping.Cart;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<Domain.Models.Carts.Cart, AddCartCommand>().ReverseMap();
        CreateMap<Domain.Models.Carts.Cart, CartDto>().ReverseMap();
    }
}