using DotNetCleanTemplate.Source.Domain.Entities.Auth;

public interface IUserRepository
{
    public Task<List<User>>   GetAllUsers();
    public Task<User?>        GetUserById(Guid Id);
    public Task<User?>        AddNewUser(User user);
    public Task<int?>         DeleteUserById(Guid Id);
    public Task<User?>        UpdateUserById(Guid Id, User user);
}
