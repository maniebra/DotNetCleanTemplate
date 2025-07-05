namespace DotNetCleanTemplate.Source.Infrastructure.Commons.Documentation;

using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class ExampleSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var exampleObject = new OpenApiObject();

        // Handle record primary constructor parameters with [Example]
        var ctor = context.Type.GetConstructors().FirstOrDefault();
        if (ctor != null)
        {
            foreach (var param in ctor.GetParameters())
            {
                var attr = param.GetCustomAttribute<ExampleAttribute>();
                if (attr != null)
                {
                    exampleObject[param.Name!] = ToOpenApiAny(attr.Value);
                }
            }
        }

        // Also support [Example] on regular properties
        foreach (var prop in context.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            var attr = prop.GetCustomAttribute<ExampleAttribute>();
            if (attr != null)
            {
                exampleObject[prop.Name] = ToOpenApiAny(attr.Value);
            }
        }

        if (exampleObject.Any())
        {
            schema.Example = exampleObject;
        }
    }

    private static IOpenApiAny ToOpenApiAny(object value) => value switch
    {
        string s => new OpenApiString(s),
        int i => new OpenApiInteger(i),
        bool b => new OpenApiBoolean(b),
        double d => new OpenApiDouble(d),
        float f => new OpenApiFloat(f),
        _ => new OpenApiString(value?.ToString() ?? string.Empty)
    };
}

