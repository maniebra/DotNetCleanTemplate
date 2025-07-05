using Microsoft.EntityFrameworkCore;

namespace DotNetCleanTemplate.Source.Infrastructure.Commons.Generics;

public class RepositoryBase<T> where T : class
{
    protected DbContext _context;
    protected DbSet<T> _dbSet;

    public RepositoryBase(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
}