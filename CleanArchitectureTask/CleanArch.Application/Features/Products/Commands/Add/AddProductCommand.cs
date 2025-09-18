using CleanArch.Application.Abstractions.Messaging;

namespace CleanArch.Application.Features.Products.Commands.Add;

public record AddProductCommand(
    string Name, 
    string Description,
    decimal Price, 
    int Stock, 
    Guid CategoryId = default
    ) : ICommand<string>;