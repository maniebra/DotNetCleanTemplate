using DotNetCleanTemplate.Source.Infrastructure.Commons;
using DotNetCleanTemplate.Source.Infrastructure.Options;
using DotNetCleanTemplate.Source.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DotNetCleanTemplate.Source.Infrastructure.Options;

/// <summary>
/// Configures the application's database services.
/// </summary>
public static class DbOptions
{
    /// <summary>
    /// Registers the application's DbContext and related database options.
    /// </summary>
    /// <param name="builder">The builder without db context</param>
    /// <returns>The updated builder.</returns>
    public static WebApplicationBuilder AddDbOptions(this WebApplicationBuilder builder)
    {
        var postgresConnectionString = Constants.ConnectionString;

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(postgresConnectionString);
        });

        return builder;
    }
}