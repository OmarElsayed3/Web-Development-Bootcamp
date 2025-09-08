using System.Net;
using AuthTask1.Controllers.Base;
using AuthTask1.Models;
using AuthTask1.Services.Interfaces.IEmailService;
using Microsoft.AspNetCore.Mvc;

namespace AuthTask1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : BaseController
{
    private readonly IMailConfirmationService _emailService;

    public EmailController(IMailConfirmationService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send-confirmation")]
    public async Task<IActionResult> SendConfirmationEmail([FromForm] string mail)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var response = await _emailService.SendEmailAsync(mail);
        return StatusCode((int)response.StatusCode, response);
    }
    [HttpPost("verify-email")]
    public async Task<IActionResult> VerifyEmail([FromForm] string mail, [FromForm] string otp)
    {
        if (!ModelState.IsValid)
        {
            return Result(new Response<object>
            {
                Data = ModelState,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        var response = await _emailService.VerifyOtpAsync(mail, otp);
        return StatusCode((int)response.StatusCode, response);
    }
    

}