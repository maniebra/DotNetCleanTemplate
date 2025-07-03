using DotNetCleanTemplate.Source.Infrastructure.DI.Interfaces;

namespace DotNetCleanTemplate.Source.Infrastructure.DI;

public class AppModule
{
    public static WebApplicationBuilder RegisterUtils(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IPasswordUtil, PasswordUtil>();
        builder.Services.AddScoped<IJwtUtil, JwtUtil>();
        
        return builder;
    }
}