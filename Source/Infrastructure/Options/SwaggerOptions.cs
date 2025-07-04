using Microsoft.OpenApi.Models;
using Constants = DotNetCleanTemplate.Source.Infrastructure.Commons.Constants;

namespace DotNetCleanTemplate.Source.Infrastructure.Options;

public static class SwaggerOptions
{
    public static WebApplicationBuilder AddSwaggerOptions(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My API",
                Version = "v1",
                Description = ".NET Clean Architecture Web API"
            });
            
            options.IncludeXmlComments(Constants.XmlPath);
        });
        return builder;
    }
}