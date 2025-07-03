using Microsoft.EntityFrameworkCore;

namespace DotNetCleanTemplate.Source.Persistence.DbContexts;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    
}