using Microsoft.AspNetCore.Identity;

namespace AuthTask1.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual Cart Cart { get; set; }
}