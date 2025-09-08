using AuthTask1.Dto.Email;

namespace AuthTask1.Services.Interfaces.IEmailService;

public interface IEmailService
{
    Task SendEmailAsync(EmailModel emailModel, EmailSubject subject, HtmlTemplate htmlTemplate);
}