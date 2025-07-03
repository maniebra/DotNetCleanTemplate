namespace DotNetCleanTemplate.Source.Common;

public static class Constants
{
    //      [   APP    ]
    public static readonly string? AppId = Environment.GetEnvironmentVariable("AppId");
    public static readonly string? AppSecret = Environment.GetEnvironmentVariable("AppSecret");

    //      [ SECURITY ]
    public static readonly string? SecretKey = Environment.GetEnvironmentVariable("SecretKey");
    
    //      [ DATABASE ]
    public static readonly string? ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
}