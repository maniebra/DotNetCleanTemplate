using DotNetCleanTemplate.Source.Domain.Entities.Auth;
using DotNetCleanTemplate.Source.Infrastructure.Commons.Documentation;

public class RegisterUserResponse
{
    [Example("john.doe")]
    public string Username { get; init; }

    [Example("John")]
    public string FirstName { get; init; }

    [Example("Doe")]
    public string LastName { get; init; }

    [Example("2025-10-07 12:21:23T")]
    public DateTime CreatedAt { get; init; }

    public static RegisterUserResponse FromUser(User user)
    {
        return new RegisterUserResponse {
            Username  = user.Username,
            FirstName = user.FirstName,
            LastName  =  user.LastName,
            CreatedAt = user.CreatedAt,
        };
    }
}
