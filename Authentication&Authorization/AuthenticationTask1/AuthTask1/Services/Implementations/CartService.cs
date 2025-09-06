using AuthTask1.Data;
using AuthTask1.Dto;
using AuthTask1.Dto.Cart;
using AuthTask1.Services.Interfaces;
using AuthTask1.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthTask1.Services.Implementations;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;
    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Response<CartDto>> AddToCart(CartDto addToCart, string userId)
    {
        var response = new Response<CartDto>();
        var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null)
        {
            cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }
        foreach (var itemDto in addToCart.CartItems)
        {
            var product = await _context.Products.FindAsync(itemDto.ProductId);
            if (product == null)
            {
                response.Message = $"Product with ID {itemDto.ProductId} not found.";
                response.Status = false;
                return response;
            }
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == itemDto.ProductId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    Price = product.Price,
                    CartId = cart.Id
                };
                cart.CartItems.Add(cartItem);
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += itemDto.Quantity;
            }
        }
        await _context.SaveChangesAsync();
        response.Data = await GetCartDto(cart);
        response.Status = true;
        response.Message = "Product(s) added to cart.";
        return response;
    }

    public async Task<Response<CartDto>> GetCartByUserId(string userId)
    {
        var response = new Response<CartDto>();
        var cart = await _context.Carts.Include(c => c.CartItems).ThenInclude(ci => ci.Product).FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null)
        {
            response.Message = "Cart not found.";
            response.Status = false;
            return response;
        }
        response.Data = await GetCartDto(cart);
        response.Status = true;
        return response;
    }
    
    public async Task<Response<string>> RemoveFromCart(string userId, string productId)
    {
        var response = new Response<string>();
        var cart = await _context.Carts.Include(c => c.CartItems).FirstOrDefaultAsync(c => c.UserId == userId);
        if (cart == null)
        {
            response.Message = "Cart not found.";
            response.Status = false;
            return response;
        }
        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId.ToString() == productId);
        if (cartItem == null)
        {
            response.Message = "Product not found in cart.";
            response.Status = false;
            return response;
        }
        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        response.Data = "Product removed from cart.";
        response.Status = true;
        return response;
    }

    private async Task<CartDto> GetCartDto(Cart cart)
    {
        var user = await _context.Users.FindAsync(cart.UserId);
        return new CartDto
        {
            UserId = cart.UserId,
            UName = user?.UserName,
            CartItems = cart.CartItems.Select(ci => new CartItemDto
            {
                ProductId = ci.ProductId,
                ProductName = ci.Product?.Name ?? "",
                Quantity = ci.Quantity
            }).ToList()
        };
    }
}