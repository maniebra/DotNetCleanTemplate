using DotNetCleanTemplate.Source.Infrastructure.Commons.Documentation;

namespace DotNetCleanTemplate.Source.Presentation.Contracts.Requests.User;

public class RegisterUserRequest {
    [Example("john.doe")]
    public required string username { get; init; }
    
    [Example("J0hnDoe!142")]
    public required string password { get; init; }

    [Example("john.doe@gmail.com")]
    public required string email { get; init; }

    [Example("+1109823212")]
    public string? phone_number { get; init; } = null;
}
