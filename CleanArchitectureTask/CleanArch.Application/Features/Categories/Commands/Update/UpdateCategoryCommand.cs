using CleanArch.Application.Abstractions.Messaging;
using MediatR;

namespace CleanArch.Application.Features.Categories.Commands.Update;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    string? Description
) : ICommand<Guid>;

