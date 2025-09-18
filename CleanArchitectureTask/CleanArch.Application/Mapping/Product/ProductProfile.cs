using AutoMapper;
using CleanArch.Application.Features.Products.Commands.Add;
using CleanArch.Application.Features.Products.Dtos;

namespace CleanArch.Application.Mapping.Product;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<AddProductCommand, Domain.Models.Products.Product>();
        CreateMap<Domain.Models.Products.Product, ProductDto>().ReverseMap();
    }
}