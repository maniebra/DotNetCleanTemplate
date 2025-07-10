using DotNetCleanTemplate.Source.Domain.Entities.Auth;

namespace DotNetCleanTemplate.Source.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>>   GetAllUsers();
    public Task<User?>        GetUserById(Guid id);
    public Task<User?>        GetUserByUsername(string username);
    public Task<User?>        AddNewUser(User user);
    public Task<int?>         DeleteUserById(Guid id);
    public Task<User?>        UpdateUserById(Guid id, User user);
}
