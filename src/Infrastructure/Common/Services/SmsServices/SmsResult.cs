namespace Chat.Infrastructure.Common.Services.SmsServices;

public class SmsResult
{
    public SmsResult() { }
    internal SmsResult(bool succeeded, List<SmsError> errors = null)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public bool Succeeded { get; set; }
    public List<SmsError> Errors { get; set; }

    public static SmsResult Success => new SmsResult(true, new List<SmsError> { });

    public static SmsResult Failed(List<SmsError> errors = null)
    {
        return new SmsResult(false, errors);
    }
}