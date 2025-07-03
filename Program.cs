using DotNetCleanTemplate.Source.Infrastructure.DI;
using DotNetCleanTemplate.Source.Infrastructure.Options;

var builder = WebApplication.CreateBuilder(args);
builder = BuilderOptions.UseBuilderOptions(builder);

builder = AppModule.RegisterUtils(builder);

var app = AppOptions.UseAppOptions(builder.Build());


app.Run();