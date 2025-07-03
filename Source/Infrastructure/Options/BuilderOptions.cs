namespace DotNetCleanTemplate.Source.Infrastructure.Options;

public static class BuilderOptions
{
    public static WebApplicationBuilder UseBuilderOptions(WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        
        return builder;
    }
}