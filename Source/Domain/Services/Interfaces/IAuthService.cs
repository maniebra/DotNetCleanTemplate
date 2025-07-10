using DotNetCleanTemplate.Source.Domain.Entities.Auth;
using DotNetCleanTemplate.Source.Infrastructure.Commons;

namespace DotNetCleanTemplate.Source.Domain.Services.Interfaces;

public interface IAuthService
{
    public Task<Result<User>>   RegisterUser(string username,
                                             string password,
                                             string email,
                                             string firstName,
                                             string lastName);

    public Task<Result<string>> LoginUser   (string username,
                                             string password);
}
