using System.Security.Claims;

namespace Chat.Infrastructure.Common.Services.JwtServices;

public interface IJwtService
{
    (JwtResult Status, string? Token) GenerateToken(List<Claim> claims, DateTime? expire = default);
}