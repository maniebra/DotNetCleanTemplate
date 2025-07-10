namespace DotNetCleanTemplate.Source.Infrastructure.Commons.Generics;

public static class ResponseTemplate
{
    public static Object? SuccessResponse(string message, Object? data, JsonContent? extensions = null) => new
    {
        message = message,
        data = data,
        extensions = extensions
    };

    public static Object? ErrorResponse(string message, string? errorDetails = null) => new
    {
        message = message,
        errorDetails = errorDetails
    };

    public static Object? MessageOnlyResponse(string message) => new
    {
        message = message
    };

}
