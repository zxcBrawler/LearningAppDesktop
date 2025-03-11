using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using LearningApp.DataSource;
using LearningApp.Factories;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.ViewModels;
using LearningApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace LearningApp.Utils;

public static class DependencyInjection
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddHttpClient("api", c => { c.BaseAddress = new Uri("https://localhost:7146"); })
            .AddTypedClient(RestService.For<IApiInterface>);
        services.AddSingleton<CourseService>();
        services.AddSingleton<ExerciseService>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<LogInViewModel>();
        services.AddTransient<SignUpViewModel>();
        services.AddTransient<MainAppViewModel>();
        services.AddTransient<CoursesViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<CourseDetailsViewModel>();
        services.AddTransient<ExerciseViewModel>();
        services.AddTransient<ApiService>();
        services.AddTransient<CourseDetailsView>();
        services.AddTransient<TrueFalseExerciseView>();
        services.AddTransient<MultipleChoiceExerciseView>();
        services.AddTransient<TextAnswerExerciseView>();

        services.AddSingleton<Func<Window>>(_ =>
        {
            return () =>
            {
                if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
                    {
                        MainWindow: not null
                    } desktop)
                    return desktop.MainWindow;
                return null;
            };
        });


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

        services.AddSingleton<Func<TypeExercise, UserControl>>(provider => exerciseType => exerciseType switch
        {
            TypeExercise.TrueFalse => provider.GetRequiredService<TrueFalseExerciseView>(),
            TypeExercise.MultipleChoice => provider.GetRequiredService<MultipleChoiceExerciseView>(),
            TypeExercise.TextAnswer => provider.GetRequiredService<TextAnswerExerciseView>(),
            _ => throw new ArgumentOutOfRangeException(nameof(exerciseType), exerciseType, null)
        });

        services.AddSingleton<PageFactory>();
        services.AddSingleton<ExerciseViewFactory>();
    }
}