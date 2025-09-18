using CleanArch.Domain.Responses;
using MediatR;

namespace CleanArch.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Response<TResponse>>;
