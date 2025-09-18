using System.Transactions;
using CleanArch.Application.Abstractions.Messaging;
using MediatR;

namespace CleanArch.Application.Abstractions.Behaviors;

public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!typeof(TRequest).IsAssignableTo(typeof(IBaseCommand)))
        {
            return await next();
        }
        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        TResponse response = await next();
        transaction.Complete();
        return response;
    }
}