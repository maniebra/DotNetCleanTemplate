using Microsoft.EntityFrameworkCore;

namespace DotNetCleanTemplate.Source.Infrastructure.Commons.Generics;

public class Service<T> where T : class
{
    public ILogger logger;

    public Service(ILogger logger)
    {
        this.logger = logger;
    }
}
