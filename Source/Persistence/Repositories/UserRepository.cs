using DotNetCleanTemplate.Source.Domain.Entities.Auth;
using DotNetCleanTemplate.Source.Infrastructure.Commons.Generics;
using DotNetCleanTemplate.Source.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DotNetCleanTemplate.Source.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public async Task<User?> AddNewUser(User user)
    {
        await _dbSet.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<int?> DeleteUserById(Guid id)
    {
        var user = await _dbSet.FindAsync(id);
        if (user == null)
            return null;

        _dbSet.Remove(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _dbSet
            .AsNoTracking()
            .OrderByDescending(u => u.CreatedAt)
            .ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> UpdateUserById(Guid id, User updatedUser)
    {
        var user = await _dbSet.FindAsync(id);
        if (user == null)
            return null;

        _context.Entry(user).CurrentValues.SetValues(updatedUser);
        await _context.SaveChangesAsync();
        return user;
    }
}
