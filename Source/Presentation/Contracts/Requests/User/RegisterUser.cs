using DotNetCleanTemplate.Source.Infrastructure.Commons.Documentation;

namespace DotNetCleanTemplate.Source.Presentation.Contracts.Requests.User;

public class RegisterUserRequest {
    [Example("john.doe")]
    public required string username { get; init; }
    
    [Example("J0hnDoe!142")]
    public required string password { get; init; }

    [Example("john.doe@gmail.com")]
    public required string email { get; init; }

    [Example("John")]
    public required string firstName { get; init; }

    [Example("Doe")]
    public required string lastName { get; init; }
}
