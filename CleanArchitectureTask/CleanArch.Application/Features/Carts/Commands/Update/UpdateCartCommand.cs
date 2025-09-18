using CleanArch.Application.Abstractions.Messaging;
using MediatR;
using CleanArch.Application.Features.Carts.Dtos;

namespace CleanArch.Application.Features.Carts.Commands.Update;

public record UpdateCartCommand(
    Guid Id,
    Guid UserId,
    List<CartItemDto> CartItems
) : ICommand<Guid>;
