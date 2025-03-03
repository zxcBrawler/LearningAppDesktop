using System;
using LearningApp.Factories;
using LearningApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Utils;

public static class DependencyInjection
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<LogInViewModel>();
        services.AddTransient<SignUpViewModel>();
        services.AddTransient<MainAppViewModel>();
        services.AddTransient<CoursesViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddSingleton<Func<AppPageNames, PageViewModel>>(x => name => name switch
        {
            AppPageNames.LogIn => x.GetRequiredService<LogInViewModel>(),
            AppPageNames.SignUp => x.GetRequiredService<SignUpViewModel>(),
            AppPageNames.MainApp => x.GetRequiredService<MainAppViewModel>(),
            AppPageNames.Courses => x.GetRequiredService<CoursesViewModel>(),
            AppPageNames.Settings => x.GetRequiredService<SettingsViewModel>(),
            AppPageNames.Home => x.GetRequiredService<HomeViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
        });
        services.AddSingleton<PageFactory>();
    }
}