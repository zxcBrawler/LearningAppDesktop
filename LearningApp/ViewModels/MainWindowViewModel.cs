using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.DataSource;
using LearningApp.Factories;
using LearningApp.Utils.Enum;
using LearningApp.Utils.LocalizationManager;
using LearningApp.Utils.Settings;
using LearningApp.Utils.TokenManagement;
using Refit;

namespace LearningApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IRecipient<NavigateToPageMessage>
{
    private readonly PageFactory _pageFactory;
    private readonly ITokenStorage _tokenStorage;
    private readonly IApiInterface _apiInterface;

    [ObservableProperty] private bool _isLoading;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsLogInPageActive))]
    [NotifyPropertyChangedFor(nameof(IsSignUpPageActive))]
    private PageViewModel _currentView;

    public bool IsLogInPageActive => CurrentView.PageName == AppPageNames.LogIn;
    public bool IsSignUpPageActive => CurrentView.PageName == AppPageNames.SignUp;

    public MainWindowViewModel(PageFactory pageFactory, ITokenStorage tokenStorage, IApiInterface apiInterface)
    {
        _pageFactory = pageFactory;
        _tokenStorage = tokenStorage;
        _apiInterface = apiInterface;
        IsActive = true;
    }

    public void Receive(NavigateToPageMessage message)
    {
        CurrentView = _pageFactory.GetPageViewModel(message.PageName);
    }


    [RelayCommand]
    private async Task CheckTokensAndNavigate()
    {
        IsLoading = true;
        try
        {
            await _apiInterface.LaunchApp();
            var tokensValid = _tokenStorage.ValidateTokens();
            var nextView = _pageFactory.GetPageViewModel(
                tokensValid ? AppPageNames.MainApp : AppPageNames.LogIn);

            CurrentView = nextView;
            LocalizationManager.SetLanguage(SettingsManager.LoadSettings().SelectedLanguageCode);
        }
        catch (ApiException e)
        {
            Console.WriteLine(e);
            CurrentView = _pageFactory.GetPageViewModel(AppPageNames.LogIn);
        }
        finally
        {
            IsLoading = false;
        }
    }
}

public record NavigateToPageMessage(AppPageNames PageName);