using System;
using System.ComponentModel.DataAnnotations;

namespace AuthTask1.Dto.Email;

public class OtpEntry
{
    [Key]
    public string Email { get; set; }
    public string Otp { get; set; }
    public DateTime ExpirationTime { get; set; }
}
