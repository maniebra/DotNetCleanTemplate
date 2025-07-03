using System.Security.Claims;

namespace DotNetCleanTemplate.Source.Infrastructure.Utils.Interfaces;

public interface IJwtUtil
{
    /// <summary>Create a signed JWT for the specified subject.</summary>
    string GenerateToken(string userId,
        string username,
        IEnumerable<string>? roles = null);

    /// <summary>Validate a JWT and return its claims; returns <c>null</c> if invalid/expired.</summary>
    ClaimsPrincipal? ValidateToken(string token);
}