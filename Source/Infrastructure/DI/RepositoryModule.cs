using DotNetCleanTemplate.Source.Infrastructure.Repositories;
using DotNetCleanTemplate.Source.Persistence.Repositories.Interfaces;

namespace DotNetCleanTemplate.Source.Infrastructure.DI;

public static class RepositoryModule
{
    /// <summary>
    /// Add your repositories with `builder.AddScoped`
    /// </summary>
    /// <param name="builder">web application builder</param>
    /// <returns>A web application builder with your repositories.</returns>
    public static WebApplicationBuilder RegisterRepositories(this WebApplicationBuilder builder)
    {
        // repos go here
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        return builder;
    }
}
