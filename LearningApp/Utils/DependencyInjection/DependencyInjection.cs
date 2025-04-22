using System;
using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using LearningApp.DataSource;
using LearningApp.Factories;
using LearningApp.Factories.WindowFactory;
using LearningApp.Factories.WindowViewModelFactoryImpl;
using LearningApp.Service;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Utils.Settings;
using LearningApp.Utils.TokenManagement;
using LearningApp.ViewModels;
using LearningApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace LearningApp.Utils.DependencyInjection;

[SupportedOSPlatform("windows")]
public static class DependencyInjection
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        AddHttpClients(services);
        AddAuthenticationServices(services);
        AddApplicationServices(services);
        AddViewModels(services);
        AddViews(services);
        AddFactories(services);
        AddStateServices(services);
        AddUtilities(services);
    }

    private static void AddHttpClients(IServiceCollection services)
    {
        services.AddTransient<AuthTokenHandler>(sp => new AuthTokenHandler(
            sp.GetRequiredService<ITokenStorage>(),
            new Lazy<ITokenRefreshService>(sp.GetRequiredService<ITokenRefreshService>)
        ));

        services.AddRefitClient<IApiInterface>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://localhost:7087");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .AddHttpMessageHandler<AuthTokenHandler>()
            .AddStandardResilienceHandler();
    }

    private static void AddAuthenticationServices(IServiceCollection services)
    {
        services.AddScoped<ITokenStorage, TokenStorage>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<ITokenRefreshService, TokenRefreshService>();
    }

    private static void AddApplicationServices(IServiceCollection services)
    {
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IDictionaryService, DictionaryService>();
        services.AddScoped<IWordService, WordService>();
    }

    private static void AddViewModels(IServiceCollection services)
    {
        var viewModels = new[]
        {
            typeof(MainWindowViewModel),
            typeof(LogInViewModel),
            typeof(SignUpViewModel),
            typeof(MainAppViewModel),
            typeof(CoursesViewModel),
            typeof(HomeViewModel),
            typeof(SettingsViewModel),
            typeof(CourseDetailsViewModel),
            typeof(DictionaryViewModel),
            typeof(ExerciseViewModel),
            typeof(ProfileViewModel),
            typeof(ChangeProfileDataViewModel),
            typeof(ChangePasswordViewModel),
            typeof(WordSearchViewModel),
            typeof(AddDictionaryViewModel),
            typeof(StatisticsViewModel),
            typeof(WordDetailsViewModel),
        };

        foreach (var vmType in viewModels)
        {
            services.AddTransient(vmType);
        }
    }

    private static void AddViews(IServiceCollection services)
    {
        services.AddTransient<TrueFalseExerciseView>();
        services.AddTransient<MultipleChoiceExerciseView>();
        services.AddTransient<TextAnswerExerciseView>();
    }


    private static void AddStateServices(IServiceCollection services)
    {
        services.AddSingleton<StateService.UserStateService>();
        services.AddSingleton<StateService.WordStateService>();
        services.AddSingleton<StateService.CourseStateService>();
    }

    private static void AddUtilities(IServiceCollection services)
    {
        services.AddSingleton<SettingsManager>();
    }

    private static void AddFactories(IServiceCollection services)
    {
        services.AddSingleton<Func<Window>>(_ => () =>
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
                {
                    MainWindow: not null
                } desktop)
                return desktop.MainWindow;
            return null;
        });

        services.AddSingleton<Func<AppPageNames, PageViewModel>>(provider => name => name switch
        {
            AppPageNames.LogIn => provider.GetRequiredService<LogInViewModel>(),
            AppPageNames.SignUp => provider.GetRequiredService<SignUpViewModel>(),
            AppPageNames.MainApp => provider.GetRequiredService<MainAppViewModel>(),
            AppPageNames.Courses => provider.GetRequiredService<CoursesViewModel>(),
            AppPageNames.Settings => provider.GetRequiredService<SettingsViewModel>(),
            AppPageNames.Home => provider.GetRequiredService<HomeViewModel>(),
            AppPageNames.Dictionaries => provider.GetRequiredService<DictionaryViewModel>(),
            AppPageNames.Profile => provider.GetRequiredService<ProfileViewModel>(),
            AppPageNames.ExerciseWindow => provider.GetRequiredService<ExerciseViewModel>(),
            AppPageNames.CourseDetails => provider.GetRequiredService<CourseDetailsViewModel>(),
            AppPageNames.Words => provider.GetRequiredService<WordSearchViewModel>(),
            AppPageNames.Statistics => provider.GetRequiredService<StatisticsViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
        });

        services.AddSingleton<Func<string, UserControl>>(provider => exerciseType => exerciseType switch
        {
            "TrueFalse" => provider.GetRequiredService<TrueFalseExerciseView>(),
            "MultipleChoice" => provider.GetRequiredService<MultipleChoiceExerciseView>(),
            "Text" => provider.GetRequiredService<TextAnswerExerciseView>(),
            _ => throw new ArgumentOutOfRangeException(nameof(exerciseType), exerciseType, null)
        });

        services.AddSingleton<PageFactory>();
        services.AddSingleton<ExerciseViewFactory>();
        services.AddSingleton<IWindowFactory, WindowFactory>();
        services.AddSingleton<IWindowViewModelFactory, WindowViewModelFactory>();
    }
}