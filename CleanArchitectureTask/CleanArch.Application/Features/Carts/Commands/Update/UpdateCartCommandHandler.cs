using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Domain.Models.Carts;
using CleanArch.Domain.Responses;
using MediatR;

namespace CleanArch.Application.Features.Carts.Commands.Update;

public class UpdateCartCommandHandler (IMapper mapper,IRepository<Cart> cartRepository) : ICommandHandler<UpdateCartCommand, Guid>
{
    public async Task<Response<Guid>> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.GetByIdAsync(request.Id, cancellationToken);
        if (cart == null)
            return Response<Guid>.Failure("Cart not found");
        
        cart.UserId = request.UserId;
        var requestItemIds = request.CartItems.Select(ci => ci.ProductId).ToHashSet();
        var itemsToRemove = cart.CartItems.Where(ci => !requestItemIds.Contains(ci.ProductId)).ToList();
        foreach (var item in itemsToRemove)
        {
            cart.CartItems.Remove(item);
        }
        foreach (var itemDto in request.CartItems)
        {
            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == itemDto.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity = itemDto.Quantity;
                existingItem.UnitPrice = itemDto.Price;
            }
            else
            {
                var newItem = mapper.Map<Domain.Models.CartItems.CartItem>(itemDto);
                newItem.CartId = cart.Id;
                cart.CartItems.Add(newItem);
            }
        }
        await cartRepository.UpdateAsync(cart, cancellationToken);
        return Response<Guid>.Success(cart.Id);
    }
}
