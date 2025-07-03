namespace DotNetCleanTemplate.Source.Infrastructure.Options;

public static class AppOptions
{
    public static WebApplication UseAppOptions(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapControllers();
        
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        return app;
    }
}