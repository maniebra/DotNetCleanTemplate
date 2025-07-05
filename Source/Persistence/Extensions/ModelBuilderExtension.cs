namespace DotNetCleanTemplate.Source.Persistence.Extensions;

using System.Reflection;
using Microsoft.EntityFrameworkCore;


public static class ModelBuilderExtensions
{
    public static void ApplyEntityConfigurationsFromModels(
        this ModelBuilder modelBuilder,
        Assembly assembly)
    {
        var entityMethod = typeof(ModelBuilder).GetMethods()
            .Single(m => m.Name == nameof(ModelBuilder.Entity)
                         && m.IsGenericMethod
                         && m.GetParameters().Length == 0);

        const string configureName = "Configure";

        foreach (var type in assembly.GetExportedTypes())
        {
            var configure = type.GetMethod(
                configureName,
                BindingFlags.Public | BindingFlags.Static);

            if (configure is null) continue;

            var builder = entityMethod.MakeGenericMethod(type)
                .Invoke(modelBuilder, null);

            configure.Invoke(null, new[] { builder });
        }
    }
}

