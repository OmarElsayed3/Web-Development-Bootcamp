using CleanArch.Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Http;

namespace CleanArch.Application.Features.Products.Commands.Update;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int Stock,
    Guid CategoryId
) : ICommand<Guid>;