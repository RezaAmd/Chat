using Infrastructure.Common.Services.SmsServices;

namespace Infrastructure.Common.Interfaces;

public interface ISmsService
{
    Task<SmsResult> SendAsync(string reciever, string text);
    Task<SmsResult> SendOtpAsync(string reciever, string token);
}