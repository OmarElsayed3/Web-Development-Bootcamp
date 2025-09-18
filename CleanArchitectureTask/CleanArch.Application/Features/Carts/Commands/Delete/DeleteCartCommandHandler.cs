using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Models.Carts;
using CleanArch.Domain.Models.CartItems;
using CleanArch.Domain.Responses;
using MediatR;

namespace CleanArch.Application.Features.Carts.Commands.Delete;

public class DeleteCartCommandHandler(IRepository<Cart> cartRepository, IRepository<CartItem> cartItemRepository) : ICommandHandler<DeleteCartCommand, Guid>
{
    public async Task<Response<Guid>> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.GetByIdAsync(request.Id, cancellationToken);
        if (cart is null)
        {
            return Response<Guid>.NotFound("Cart not found.");
        }
        
        foreach (var item in cart.CartItems.ToList())
        {
            await cartItemRepository.DeleteAsync(item, cancellationToken);
        }

        await cartRepository.DeleteAsync(cart, cancellationToken);
        return Response<Guid>.Success(request.Id);
    }
}
