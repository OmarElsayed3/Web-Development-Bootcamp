using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthTask1.Services.Interfaces;
using AuthTask1.Dto.Product;
using System.Net;

namespace AuthTask1.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "ProductCreator")]
public class ProductCreatorController(IProductService productService) : ControllerBase
{
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateProduct([FromForm] ProductDto dto)
    {
        var userId = User.Identity?.Name;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized("User not authenticated.");

        var response = await productService.CreateProduct(dto, userId);
        if (response.StatusCode != HttpStatusCode.OK)
            return StatusCode((int)response.StatusCode, response.Message);

        return Ok(response.Data);
    }
}
