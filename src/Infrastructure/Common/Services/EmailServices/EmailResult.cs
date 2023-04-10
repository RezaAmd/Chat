namespace Chat.Infrastructure.Common.Services.EmailServices;

public class EmailResult
{
    public EmailResult() { }
    internal EmailResult(bool succeeded, List<EmailError> errors = null)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public bool Succeeded { get; set; }
    public List<EmailError> Errors { get; set; }

    public static EmailResult Success => new EmailResult(true, new List<EmailError> { });

    public static EmailResult Failed(List<EmailError> errors = null)
    {
        return new EmailResult(false, errors);
    }
}