using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthTask1.Services.Interfaces;
using System.Net;
using AuthTask1.Dto.Product;

namespace AuthTask1.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IProductService _productService;

    public AdminController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPut("approve/{id}")]
    public async Task<IActionResult> ApproveProduct(int id)
    {
        var response = await _productService.ApproveProduct(id);
        if (response.StatusCode != HttpStatusCode.OK)
            return StatusCode((int)response.StatusCode, response.Message);

        return Ok(response.Data);
    }

    [HttpPut("reject/{id}")]
    public async Task<IActionResult> RejectProduct(int id)
    {
        var response = await _productService.RejectProduct(id);
        if (response.StatusCode != HttpStatusCode.OK)
            return StatusCode((int)response.StatusCode, response.Message);

        return Ok(response.Data);
    }
    
    [HttpGet("pending-products")]
    public async Task<IActionResult> GetPendingProducts()
    {
        var response = await _productService.GetPendingProducts();
        if (response.StatusCode != HttpStatusCode.OK)
            return StatusCode((int)response.StatusCode, response.Message);

        return Ok(response.Data);
    }
}
