using AuthTask1.Models;

namespace AuthTask1.Services.Interfaces.IEmailService;

public interface IMailConfirmationService
{
    Task<Response<object>> SendEmailAsync(string mail);
    Task<Response<bool>> VerifyOtpAsync(string mail, string otp);
}