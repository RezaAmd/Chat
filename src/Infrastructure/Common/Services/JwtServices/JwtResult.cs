using Infrastructure.Common.Services.RedisServices;

namespace Infrastructure.Common.Services.JwtServices;

public class JwtResult
{
    public JwtResult() { }
    internal JwtResult(bool succeeded, List<JwtError> errors = null)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public bool Succeeded { get; set; }
    public List<JwtError> Errors { get; set; }

    public static JwtResult Success => new JwtResult(true, new List<JwtError> { });

    public static JwtResult Failed(List<JwtError> errors = null)
    {
        return new JwtResult(false, errors);
    }
}