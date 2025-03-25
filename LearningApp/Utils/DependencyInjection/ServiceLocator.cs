using System;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Utils.DependencyInjection;

public static class ServiceLocator
{
    private static IServiceProvider? ServiceProvider { get; set; }

    public static void SetServiceProvider(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public static T? GetService<T>() where T : class
    {
        return ServiceProvider?.GetService<T>();
    }
}