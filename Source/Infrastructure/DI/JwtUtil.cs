using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotNetCleanTemplate.Source.Infrastructure.DI.Interfaces;
using DotNetCleanTemplate.Source.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DotNetCleanTemplate.Source.Infrastructure.DI;

public sealed class JwtUtil : IJwtUtil
{
    private readonly JwtOptions _opt;
    private readonly byte[]     _secretBytes;
    private readonly JwtSecurityTokenHandler _handler = new();

    public JwtUtil(IOptions<JwtOptions> options)
    {
        _opt         = options.Value;
        _secretBytes = Encoding.UTF8.GetBytes(_opt.SecretKey);
    }

    public string GenerateToken(string userId,
                                string username,
                                IEnumerable<string>? roles = null)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub,  userId),
            new(JwtRegisteredClaimNames.UniqueName, username),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (roles is not null)
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(_secretBytes),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer:  _opt.Issuer,
            audience:_opt.Audience,
            claims:  claims,
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
                ValidateIssuer           = true,
                ValidIssuer              = _opt.Issuer,
                ValidateAudience         = true,
                ValidAudience            = _opt.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey         = new SymmetricSecurityKey(_secretBytes),
                ValidateLifetime         = true,
                ClockSkew                = TimeSpan.Zero
            };

            return _handler.ValidateToken(token, parameters, out _);
        }
        catch
        {
            return null;
        }
    }
}
