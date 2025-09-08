using System;
using System.Threading.Tasks;
using AuthTask1.Dto.Email;

namespace AuthTask1.Services.Interfaces;

public interface IOtpEntryService
{
    Task AddOrUpdateOtpAsync(OtpEntry otpEntry);
    Task<OtpEntry> GetValidOtpAsync(string email, string otp);
    Task RemoveExpiredOtpsAsync();
}
