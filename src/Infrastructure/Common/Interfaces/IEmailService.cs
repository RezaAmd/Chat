using Infrastructure.Common.Services.EmailServices;

namespace Infrastructure.Common.Interfaces;

public interface IEmailService
{
    Task<EmailResult> SendAsync(string reciever, string subject, string body, string from, string recieverName = default);
}