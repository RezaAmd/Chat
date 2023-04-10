namespace Chat.Infrastructure.Common.Services.RedisServices;


public class RedisResult
{
    public RedisResult() { }
    internal RedisResult(bool succeeded, List<RedisError> errors = null)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public bool Succeeded { get; set; }
    public List<RedisError> Errors { get; set; }

    public static RedisResult Success => new RedisResult(true, new List<RedisError> { });

    public static RedisResult Failed(List<RedisError> errors = null)
    {
        return new RedisResult(false, errors);
    }
}