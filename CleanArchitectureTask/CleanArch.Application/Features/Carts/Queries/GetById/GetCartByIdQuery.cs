using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Features.Carts.Dtos;

namespace CleanArch.Application.Features.Carts.Queries.GetById;

public record GetCartByIdQuery(Guid Id) : IQuery<CartDto>;

