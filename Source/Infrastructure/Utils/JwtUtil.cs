using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetCleanTemplate.Source.Infrastructure.Options;
using DotNetCleanTemplate.Source.Infrastructure.Utils.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DotNetCleanTemplate.Source.Infrastructure.Utils;

public sealed class JwtUtil : IJwtUtil
{
    private readonly JwtOptions _opt;
    private readonly byte[] _secretBytes;
    private readonly JwtSecurityTokenHandler _handler = new();

    public JwtUtil(IOptions<JwtOptions> options)
    {
        _opt = options.Value;
        _secretBytes = Encoding.UTF8.GetBytes(_opt.SecretKey);
    }

    public string GenerateToken(Guid userId, string username, bool isAdmin, bool isStaff)
    {
        var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new(JwtRegisteredClaimNames.UniqueName, username),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new("isAdmin", isAdmin.ToString().ToLowerInvariant()),
        new("isStaff", isStaff.ToString().ToLowerInvariant())
    };

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(_secretBytes),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _opt.Issuer,
            audience: _opt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_opt.LifeTime),
            signingCredentials: creds);

        return _handler.WriteToken(token);
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        try
        {
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _opt.Issuer,
                ValidateAudience = true,
                ValidAudience = _opt.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_secretBytes),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            return _handler.ValidateToken(token, parameters, out _);
        }
        catch
        {
            return null;
        }
    }
}
