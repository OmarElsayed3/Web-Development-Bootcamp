using CleanArch.Application.Abstractions.Messaging;
using MediatR;

namespace CleanArch.Application.Features.Categories.Commands.Delete;

public record DeleteCategoryCommand(Guid Id) : ICommand<Guid>;

