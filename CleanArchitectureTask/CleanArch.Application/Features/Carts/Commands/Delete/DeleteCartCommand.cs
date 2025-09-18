using CleanArch.Application.Abstractions.Messaging;
using MediatR;

namespace CleanArch.Application.Features.Carts.Commands.Delete;

public record DeleteCartCommand(Guid Id) : ICommand<Guid>;

