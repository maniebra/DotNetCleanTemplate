using DotNetCleanTemplate.Source.Infrastructure.Commons.Documentation;

public record LoginUserRequest
{
    [Example("john.doe")]
    public required string username { get; init; }

    [Example("J0hnDoe!142")]
    public required string password { get; init; }
}
