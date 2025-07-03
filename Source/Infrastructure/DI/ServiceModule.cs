using DotNetCleanTemplate.Source.Domain.Services;
using DotNetCleanTemplate.Source.Domain.Services.Interfaces;

namespace DotNetCleanTemplate.Source.Infrastructure.DI;

public static class ServiceModule
{
    public static WebApplicationBuilder RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthService, AuthService>();
        return builder;
    }
}