using CleanArch.Application.Abstractions.Messaging;

namespace CleanArch.Application.Features.Products.Commands.Delete;

public record DeleteProductCommand(Guid Id) : ICommand<Guid>;