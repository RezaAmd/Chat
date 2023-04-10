namespace Chat.Infrastructure.Common.Services.EmailServices;

public class EmailError
{
    public EmailError(long code, string message)
    {
        Code = code;
        Message = message;
    }

    public long Code { get; set; }
    public string Message { get; set; }
}
