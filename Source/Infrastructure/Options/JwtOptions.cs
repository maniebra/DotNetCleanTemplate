using DotNetCleanTemplate.Source.Infrastructure.Commons;

namespace DotNetCleanTemplate.Source.Infrastructure.Options;

public class JwtOptions
{
    public string? SecretKey { get; set; } = Constants.AppSecret;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int LifeTime { get; set; } = 300;
}