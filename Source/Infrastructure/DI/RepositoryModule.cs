namespace DotNetCleanTemplate.Source.Infrastructure.DI;

public static class RepositoryModule
{
    /// <summary>
    /// Add your repositories with `builder.AddScoped`
    /// </summary>
    /// <param name="builder">web application builder</param>
    /// <returns>A web application builder with your repositories.</returns>
    public static WebApplicationBuilder RegisterRepositories(WebApplicationBuilder builder)
    {
        // repos go here
        
        return builder;
    }
}