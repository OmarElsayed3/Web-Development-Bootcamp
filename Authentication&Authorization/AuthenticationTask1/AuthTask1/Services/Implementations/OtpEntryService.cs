using AuthTask1.Data;
using AuthTask1.Dto.Email;
using AuthTask1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuthTask1.Services.Implementations;

public class OtpEntryService : IOtpEntryService
{
    private readonly ApplicationDbContext _dbContext;

    public OtpEntryService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddOrUpdateOtpAsync(OtpEntry otpEntry)
    {
        var entry = await _dbContext.OtpEntries.FirstOrDefaultAsync(e => e.Email == otpEntry.Email);
        if (entry == null)
        {
            entry = new OtpEntry
            {
                Email = otpEntry.Email,
                Otp = otpEntry.Otp,
                ExpirationTime = otpEntry.ExpirationTime
            };
            _dbContext.OtpEntries.Add(entry);
        }
        else
        {
            entry.Otp = otpEntry.Otp;
            entry.ExpirationTime = otpEntry.ExpirationTime;
            _dbContext.OtpEntries.Update(entry);
        }
        await _dbContext.SaveChangesAsync();
    }

    public async Task<OtpEntry> GetValidOtpAsync(string email, string otp)
    {
        var entry = await _dbContext.OtpEntries
            .FirstOrDefaultAsync(e => e.Email == email && e.Otp == otp && e.ExpirationTime > DateTime.UtcNow);

        if (entry == null) return null;

        return new OtpEntry
        {
            Email = entry.Email,
            Otp = entry.Otp,
            ExpirationTime = entry.ExpirationTime
        };
    }

    public async Task RemoveExpiredOtpsAsync()
    {
        var expiredEntries = await _dbContext.OtpEntries
            .Where(e => e.ExpirationTime <= DateTime.UtcNow)
            .ToListAsync();

        if (expiredEntries.Any())
        {
            _dbContext.OtpEntries.RemoveRange(expiredEntries);
            await _dbContext.SaveChangesAsync();
        }
    }
}
