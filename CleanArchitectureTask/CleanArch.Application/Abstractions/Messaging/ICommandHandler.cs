using CleanArch.Domain.Responses;
using MediatR;

namespace CleanArch.Application.Abstractions.Messaging;

public interface ICommandHandler<in TCommand, TResponse> :
    IRequestHandler<TCommand, Response<TResponse>>
    where TCommand : ICommand<TResponse>;