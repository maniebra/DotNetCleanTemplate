using DotNetCleanTemplate.Source.Infrastructure.Utils;
using DotNetCleanTemplate.Source.Infrastructure.Utils.Interfaces;

namespace DotNetCleanTemplate.Source.Infrastructure.DI;

public static class UtilModule
{
    public static WebApplicationBuilder RegisterUtils(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPasswordUtil, PasswordUtil>();
        builder.Services.AddScoped<IJwtUtil, JwtUtil>();
        
        return builder;
    }
}