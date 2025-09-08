using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AuthTask1.Data;

namespace AuthTask1.Helpers.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class ValidateSessionAttribute : Attribute, IActionFilter
{
    private readonly string _parameterName;

    public ValidateSessionAttribute(string parameterName = "sessionId")
    {
        _parameterName = parameterName;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ActionArguments.TryGetValue(_parameterName, out var value) || value is not string encodedSession)
        {
            context.Result = new BadRequestObjectResult("Session ID is missing.");
            return;
        }

        try
        {
            var decodedBytes = Convert.FromBase64String(encodedSession);
            var decodedString = Encoding.UTF8.GetString(decodedBytes);

            var parts = decodedString.Split('|');
            if (parts.Length != 2 || !long.TryParse(parts[1], out var expirationTicks))
            {
                context.Result = new BadRequestObjectResult("Invalid session format.");
                return;
            }

            var userId = parts[0];
            var expiration = new DateTime(expirationTicks, DateTimeKind.Utc);

            // Debugging logs
            Console.WriteLine($"Decoded Session: {decodedString}");
            Console.WriteLine($"User ID: {userId}, Expiration: {expiration}");

            // Check session in the database
            using (var scope = context.HttpContext.RequestServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var otpEntry = dbContext?.OtpEntries.FirstOrDefault(e => e.Email == userId && e.ExpirationTime == expiration);

                if (otpEntry == null)
                {
                    context.Result = new UnauthorizedObjectResult("Session not found or invalid.");
                    return;
                }
            }

            if (DateTime.UtcNow > expiration)
            {
                context.Result = new UnauthorizedObjectResult("Session expired.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Decoding Error: {ex.Message}");
            context.Result = new BadRequestObjectResult("Invalid session encoding.");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
