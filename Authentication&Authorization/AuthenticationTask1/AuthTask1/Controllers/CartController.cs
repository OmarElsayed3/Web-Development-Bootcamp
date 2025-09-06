using AuthTask1.Controllers.Base;
using AuthTask1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthTask1.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User,Admin")]
public class CartController : BaseController
{
    private readonly ICartService _cartService;
    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User ID not found.");
        }
        var result = await _cartService.GetCartByUserId(userId);
        if (!result.Status)
        {
            return BadRequest(new { result.Status, result.Message, result.StatusCode });
        }
        return Ok(new { result.Status, result.Message, result.StatusCode, result.Data });
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart([FromBody] AuthTask1.Dto.Cart.CartDto cartDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User ID not found.");
        }
        var result = await _cartService.AddToCart(cartDto, userId);
        if (!result.Status)
        {
            return BadRequest(new { result.Status, result.Message, result.StatusCode });
        }
        return Ok(new { result.Status, result.Message, result.StatusCode, result.Data });
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> RemoveFromCart(string productId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("User ID not found.");
        }
        var result = await _cartService.RemoveFromCart(userId, productId);
        if (!result.Status)
        {
            return BadRequest(new { result.Status, result.Message, result.StatusCode });
        }
        return Ok(new { result.Status, result.Message, result.StatusCode, result.Data });
    }
}