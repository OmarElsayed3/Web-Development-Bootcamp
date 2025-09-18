namespace CleanArch.Application.Features.Carts.Dtos;

public record CartDto(
    Guid UserId,
    decimal TotalPrice,
    List<CartItemDto> CartItems
);

