using Chat.Infrastructure.Common.Services.SmsServices;

namespace Chat.Infrastructure.Common.Interfaces;

public interface ISmsService
{
    Task<SmsResult> SendAsync(string reciever, string text);
    Task<SmsResult> SendOtpAsync(string reciever, string token);
}