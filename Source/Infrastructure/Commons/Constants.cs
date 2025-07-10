using System.Reflection;

namespace DotNetCleanTemplate.Source.Infrastructure.Commons;

public static class Constants
{
    //      [ APP      ]
    public static readonly  string?     AppId = Environment.GetEnvironmentVariable("AppId");
    public static readonly  string?     AppSecret = Environment.GetEnvironmentVariable("AppSecret");

    //      [ SECURITY ]
    public static readonly  string?     SecretKey = Environment.GetEnvironmentVariable("SecretKey");
    public static           int         LifeTime = 300;
    
    //      [ DATABASE ]
    public static readonly  string?     ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
    
    //      [ API DOCS ]
    public static readonly  string      XmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    public static readonly  string      XmlPath = Path.Combine(AppContext.BaseDirectory, XmlFileName);

}
