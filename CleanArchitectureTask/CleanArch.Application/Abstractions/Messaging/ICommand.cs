using CleanArch.Domain.Responses;
using MediatR;

namespace CleanArch.Application.Abstractions.Messaging;

public interface ICommand<TResponse> : IRequest<Response<TResponse>>;