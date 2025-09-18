using AutoMapper;
using CleanArch.Application.Abstractions.Messaging;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Application.Features.Carts.Dtos;
using CleanArch.Domain.Models.CartItems;
using CleanArch.Domain.Models.Carts;
using CleanArch.Domain.Models.Products;
using CleanArch.Domain.Responses;

namespace CleanArch.Application.Features.Carts.Commands.Add;

public class AddCartCommandHandler(IMapper mapper, IRepository<Cart> cartRepository, IRepository<Product> productRepository,
    IRepository<CartItem> cartItemRepository) : ICommandHandler<AddCartCommand, string>
{
    public async Task<Response<string>> Handle(AddCartCommand request, CancellationToken cancellationToken)
    {
        var cart = new Cart
        {
            UserId = request.UserId,
            CartItems = mapper.Map<List<CartItem>>(request.CartItems)
        };
        await cartRepository.AddAsync(cart, cancellationToken);
        foreach (var item in cart.CartItems)
        {
            var product = await productRepository.GetByIdAsync(item.ProductId, cancellationToken);
            if (product == null)
            {
                return Response<string>.Failure($"Product with ID {item.ProductId} not found.");
            }
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == item.ProductId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price * item.Quantity,
                    CartId = cart.Id
                };
                await cartItemRepository.AddAsync(cartItem, cancellationToken);
            }
            else
            {
                cartItem.Quantity += item.Quantity;
            }
            
        }
        return Response<string>.Success();
    }
}

