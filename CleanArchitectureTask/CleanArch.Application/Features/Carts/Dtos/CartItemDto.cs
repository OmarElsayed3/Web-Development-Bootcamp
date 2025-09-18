namespace CleanArch.Application.Features.Carts.Dtos;

public record CartItemDto(
    Guid ProductId,
    string ProductName,
    decimal Price,
    int Quantity
);