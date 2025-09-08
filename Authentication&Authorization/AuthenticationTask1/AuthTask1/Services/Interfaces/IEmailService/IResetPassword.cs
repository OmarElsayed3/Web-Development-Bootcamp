using AuthTask1.Models;

namespace AuthTask1.Services.Interfaces.IEmailService;

public interface IResetPassword
{
    Task<Response<object>> ForgetPasswordAsync(string Mail); 
    Task<Response<bool>> VerifyPasswordOtpAsync(string mail, string otp);
    Task<Response<bool>> ResetPasswordAsync(string userId, string newPassword);
}