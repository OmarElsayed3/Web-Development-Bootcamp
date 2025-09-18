using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Features.Products.Dtos;

namespace CleanArch.Application.Features.Products.Queries.GetById;

public record GetProductByIdQuery(Guid Id) : IQuery<ProductDto>;