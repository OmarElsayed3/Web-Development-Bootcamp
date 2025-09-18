using CleanArch.Application.Abstractions.Messaging;
using MediatR;

namespace CleanArch.Application.Features.Categories.Commands.Add;

public record AddCategoryCommand(
    string Name,
    string? Description
) : ICommand<string>;

