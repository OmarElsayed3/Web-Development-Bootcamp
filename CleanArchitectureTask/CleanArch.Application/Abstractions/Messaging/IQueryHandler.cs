using CleanArch.Domain.Responses;
using MediatR;

namespace CleanArch.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Response<TResponse>>
    where TQuery : IQuery<TResponse>;