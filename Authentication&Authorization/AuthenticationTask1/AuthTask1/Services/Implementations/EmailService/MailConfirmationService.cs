using System.Net;
using AuthTask1.Dto.Email;
using AuthTask1.Models;
using AuthTask1.Services.Interfaces;
using AuthTask1.Services.Interfaces.IEmailService;

namespace AuthTask1.Services.Implementations.EmailService;

public class MailConfirmationService : IMailConfirmationService
{
    private readonly IEmailService _emailService;
    private readonly IOtpEntryService _otpEntryService;

    public MailConfirmationService(IEmailService emailService, IOtpEntryService otpEntryService)
    {
        _emailService = emailService;
        _otpEntryService = otpEntryService;
    }
    
    public async Task InitializeAsync()
    {
        await _otpEntryService.RemoveExpiredOtpsAsync();
    }

    public async Task<Response<object>> SendEmailAsync(string mail)
    {
        var otp = new Random().Next(1000, 9999).ToString();
        var expiry = DateTime.UtcNow.AddMinutes(7);

        await _otpEntryService.AddOrUpdateOtpAsync(new OtpEntry
        {
            Email = mail,
            Otp = otp,
            ExpirationTime = expiry
        });
        
        var emailModel = new ConfirmEmailModel(
            ToName: "User",
            ToMail: mail,
            Code: otp,
            Token: "",
            ExpiredInMinutes: 7
        );
        await _emailService.SendEmailAsync(emailModel, EmailSubject.ConfirmEmail, HtmlTemplate.ConfirmEmail);
        return new Response<object>
        {
            Message = "Mail sent successfully",
            StatusCode = HttpStatusCode.OK
        };
    }

    public async Task<Response<bool>> VerifyOtpAsync(string mail, string otp)
    {
        var validOtp = await _otpEntryService.GetValidOtpAsync(mail, otp);
        if (validOtp != null)
        {
            await _otpEntryService.RemoveExpiredOtpsAsync();
            return new Response<bool>
            {
                Message = "Email verified successfully",
                StatusCode = HttpStatusCode.OK
            };
        }

        return new Response<bool>
        {
            Message = "Invalid or expired OTP",
            StatusCode = HttpStatusCode.BadRequest
        };
    }

}