using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthTask1.Services.Interfaces;
using System.Net;

namespace AuthTask1.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await _productService.GetApprovedProducts();
        if (response.StatusCode != HttpStatusCode.OK)
            return StatusCode((int)response.StatusCode, response.Message);

        return Ok(response.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var response = await _productService.GetProductById(id);
        if (response.StatusCode != HttpStatusCode.OK)
            return StatusCode((int)response.StatusCode, response.Message);

        return Ok(response.Data);
    }
}
