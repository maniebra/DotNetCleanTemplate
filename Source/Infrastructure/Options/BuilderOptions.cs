namespace DotNetCleanTemplate.Source.Infrastructure.Options;

public static class BuilderOptions
{
    public static WebApplicationBuilder UseBuilderOptions(this WebApplicationBuilder builder)
    {
        builder.AddDbOptions();
        builder.AddSwaggerOptions();
        
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder;
    }
}