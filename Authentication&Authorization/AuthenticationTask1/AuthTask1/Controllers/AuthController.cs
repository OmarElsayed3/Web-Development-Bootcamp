using System.Net;
using AuthTask1.Controllers.Base;
using AuthTask1.Dto;
using AuthTask1.Models;
using AuthTask1.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthTask1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _authService.Register(model);
        return Result(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var result = await _authService.Login(model);
        return Result(result);
    }

    [Authorize]
    [HttpGet]
    [Route("test")]
    public async Task<IActionResult> TestAuthorize()
    {
        return Result(new Response<string>
        {
            Data = "Authorized",
            StatusCode = HttpStatusCode.OK
        });
    }
}
