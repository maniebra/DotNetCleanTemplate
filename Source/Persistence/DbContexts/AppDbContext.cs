using Microsoft.EntityFrameworkCore;

namespace DotNetCleanTemplate.Source.Persistence.DbContexts;


public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options);