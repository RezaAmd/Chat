namespace Chat.Infrastructure.Common.Services.SmsServices;

public class SmsError
{
    public SmsError(long code, string message)
    {
        Code = code;
        Message = message;
    }

    public long Code { get; set; }
    public string Message { get; set; }
}