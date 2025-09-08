using System.Net;
using AuthTask1.Helpers.Attributes;
using AuthTask1.Services.Interfaces.IEmailService;
using Microsoft.AspNetCore.Mvc;

namespace AuthTask1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResetPasswordController : ControllerBase
{
    private readonly IResetPassword _resetPassword;
    
    private string _sessionId;
    public ResetPasswordController(IResetPassword resetPassword)
    {
        _resetPassword = resetPassword;
    }
    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword([FromForm] string mail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var response = await _resetPassword.ForgetPasswordAsync(mail);
        return StatusCode((int)response.StatusCode, response);
    }

    [HttpPost("verify")]
    public async Task<IActionResult> VerifyOtp([FromForm] string mail, [FromForm] string otp)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }

        var response = await _resetPassword.VerifyPasswordOtpAsync(mail, otp);
        return StatusCode((int)response.StatusCode, response);
    }
    [HttpPost("reset")]
    //[ValidateSession]
    public async Task<IActionResult> ResetPassword([FromForm] string sessionId, [FromForm] string newPassword)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }

        var response = await _resetPassword.ResetPasswordAsync(sessionId, newPassword);
        return StatusCode((int)response.StatusCode, response);
    }
}