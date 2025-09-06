using AuthTask1.Dto;
using AuthTask1.Dto.Cart;
using AuthTask1.Models;

namespace AuthTask1.Services.Interfaces;

public interface ICartService
{
    public Task<Response<CartDto>> GetCartByUserId(string userId);
    public Task<Response<CartDto>> AddToCart(CartDto addToCart, string userId);
    public Task<Response<string>> RemoveFromCart(string userId, string productId);
}