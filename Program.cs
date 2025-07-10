using DotNetCleanTemplate.Source.Infrastructure.DI;
using DotNetCleanTemplate.Source.Infrastructure.Options;

var builder = WebApplication.CreateBuilder(args);

builder.UseBuilderOptions();

builder.RegisterUtils();
builder.RegisterRepositories();
builder.RegisterServices();

builder.Build().UseAppOptions().Run();

