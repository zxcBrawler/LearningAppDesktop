using System;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using LearningApp.DataSource;
using LearningApp.Factories;
using LearningApp.Service;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Utils.Settings;
using LearningApp.Utils.TokenManagement;
using LearningApp.ViewModels;
using LearningApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using TypeExercise = LearningApp.Utils.Enum.TypeExercise;

namespace LearningApp.Utils.DependencyInjection;

public static class DependencyInjection
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<ITokenRefreshService, TokenRefreshService>();
        services.AddScoped<IProfileService, ProfileService>();
        services.AddTransient<AuthTokenHandler>(sp => new AuthTokenHandler(
            sp.GetRequiredService<ITokenStorage>(),
            new Lazy<ITokenRefreshService>(sp.GetRequiredService<ITokenRefreshService>)
        ));
        services.AddScoped<ITokenStorage, TokenStorage>();

        services.AddRefitClient<IApiInterface>(new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                })
            })
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://localhost:7087");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<AuthTokenHandler>()
            .AddStandardResilienceHandler();

        services.AddTransient<CourseService>();
        services.AddSingleton<SettingsManager>();
        services.AddSingleton<UserStateService>();
        services.AddTransient<ExerciseService>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<LogInViewModel>();
        services.AddTransient<SignUpViewModel>();
        services.AddTransient<MainAppViewModel>();
        services.AddTransient<CoursesViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<CourseDetailsViewModel>();
        services.AddTransient<DictionaryViewModel>();
        services.AddTransient<ExerciseViewModel>();
        services.AddTransient<CourseDetailsView>();
        services.AddTransient<ProfileViewModel>();
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
            AppPageNames.Dictionaries => x.GetRequiredService<DictionaryViewModel>(),
            AppPageNames.Profile => x.GetRequiredService<ProfileViewModel>(),
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