namespace DotNetCleanTemplate.Source.Infrastructure.Options;

/// <summary>
/// Provides application-wide middleware and endpoint configuration options.
/// </summary>
public static class AppOptions
{
    /// <summary>
    /// Applies default middleware, controller mapping, and optional development tools to the given <see cref="WebApplication"/>.
    /// </summary>
    /// <param name="app">The application instance to configure.</param>
    /// <returns>The configured <see cref="WebApplication"/> instance.</returns>
    public static WebApplication UseAppOptions(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapControllers();

        if (!app.Environment.IsDevelopment()) return app;
        
        // DEV-MODE ONLY CONFIG
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}