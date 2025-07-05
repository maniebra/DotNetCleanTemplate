using DotNetCleanTemplate.Source.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DotNetCleanTemplate.Source.Persistence.DbContexts;


public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyEntityConfigurationsFromModels(
            typeof(AppDbContext).Assembly);
    }
}