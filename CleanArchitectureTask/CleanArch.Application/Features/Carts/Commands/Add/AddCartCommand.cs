using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Features.Carts.Dtos;
using MediatR;

namespace CleanArch.Application.Features.Carts.Commands.Add;

public record AddCartCommand(
    Guid UserId,
    List<CartItemDto> CartItems
) : ICommand<string>;

