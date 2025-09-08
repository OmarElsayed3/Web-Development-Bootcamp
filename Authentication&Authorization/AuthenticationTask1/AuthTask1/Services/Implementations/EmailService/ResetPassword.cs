using System.Net;
using AuthTask1.Data;
using AuthTask1.Dto.Email;
using AuthTask1.Models;
using AuthTask1.Services.Interfaces;
using AuthTask1.Services.Interfaces.IEmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthTask1.Services.Implementations.EmailService;

public class ResetPassword : IResetPassword
{
    private readonly IEmailService _emailService;
    private readonly ApplicationDbContext _dbContext;
    private readonly IOtpEntryService _otpEntryService;
    private readonly UserManager<User> _userManager;
    
    public ResetPassword(IEmailService emailService, ApplicationDbContext dbContext)
    {
        _emailService = emailService;
        _dbContext = dbContext;
        _otpEntryService = new OtpEntryService(dbContext);
        _userManager = new UserManager<User>(new UserStore<User>(dbContext), null!, new PasswordHasher<User>(), null!, null!, null!, null!, null!, null!);
    }

    public async Task<Response<object>> ForgetPasswordAsync(string mail)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == mail);
        if (user == null)
        {
            return new Response<object>
            {
                Message = "User not found",
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
        }

        var otp = new Random().Next(1000, 9999).ToString();
        var expiry = DateTime.UtcNow.AddMinutes(7);

        // Ensure OTP is stored in the database
        await _otpEntryService.AddOrUpdateOtpAsync(new OtpEntry
        {
            Email = mail,
            Otp = otp,
            ExpirationTime = expiry
        });

        var emailModel = new ConfirmEmailModel(
            ToName: user.UserName ?? "User",
            ToMail: mail,
            Code: otp,
            Token: "",
            ExpiredInMinutes: 7
        );
        await _emailService.SendEmailAsync(emailModel, EmailSubject.ResetPassword, HtmlTemplate.ConfirmEmail);

        return new Response<object>
        {
            Message = "Password reset OTP sent successfully",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public async Task<Response<bool>> VerifyPasswordOtpAsync(string mail, string otp)
    {
        var otpEntry = await _otpEntryService.GetValidOtpAsync(mail, otp);
        if (otpEntry == null)
        {
            await _otpEntryService.RemoveExpiredOtpsAsync();
            return new Response<bool>
            {
                Message = "Invalid or expired OTP",
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Data = false
            };
        }

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == mail);
        if (user != null)
        {
            var expirationTicks = DateTime.UtcNow.AddMinutes(15).Ticks;
            var sessionId = user.Id;

            await _otpEntryService.AddOrUpdateOtpAsync(new OtpEntry
            {
                Email = mail,
                Otp = sessionId,
                ExpirationTime = new DateTime(expirationTicks, DateTimeKind.Utc)
            });

            return new Response<bool>
            {
                Message = "verified successfully" +
                          $"Session ID: \'{sessionId}\' (valid for 15 minutes)",
                StatusCode = HttpStatusCode.OK,
                Data = true
            };
        }

        return new Response<bool>
        {
            Message = "User not found",
            StatusCode = HttpStatusCode.NotFound,
            Data = false
        };
    }

    public async Task<Response<bool>> ResetPasswordAsync(string sessionId, string newPassword)
    {
        await _otpEntryService.RemoveExpiredOtpsAsync();
        var otpEntry = await _dbContext.OtpEntries.FirstOrDefaultAsync(e => e.Otp == sessionId);
        if (otpEntry == null || otpEntry.ExpirationTime <= DateTime.UtcNow)
        {
            return new Response<bool>
            {
                Message = "Invalid or expired session",
                StatusCode = HttpStatusCode.Unauthorized,
                Data = false
            };
        }
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == sessionId);
        if (user == null)
        {
            return new Response<bool>
            {
                Message = "User not found",
                StatusCode = HttpStatusCode.NotFound,
                Data = false
            };
        }
        var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, newPassword);

        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        await _otpEntryService.RemoveExpiredOtpsAsync();
        
        return new Response<bool>
        {
            Message = "Password reset successfully",
            StatusCode = HttpStatusCode.OK,
            Data = true
        };
    }
}