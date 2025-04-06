using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Factories;
using LearningApp.Utils.Enum;
using LearningApp.Utils.TokenManagement;

namespace LearningApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IRecipient<NavigateToPageMessage>
{
    private readonly PageFactory _pageFactory;

    private readonly ITokenStorage _tokenStorage;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsLogInPageActive))]
    [NotifyPropertyChangedFor(nameof(IsSignUpPageActive))]
    private PageViewModel _currentView;

    public bool IsLogInPageActive => CurrentView.PageName == AppPageNames.LogIn;
    public bool IsSignUpPageActive => CurrentView.PageName == AppPageNames.SignUp;

    public MainWindowViewModel(PageFactory pageFactory, ITokenStorage tokenStorage)
    {
        _pageFactory = pageFactory;
        _tokenStorage = tokenStorage;
        IsActive = true;

        var tokens = tokenStorage.LoadTokens();
        CurrentView = _pageFactory.GetPageViewModel(tokens != null ? AppPageNames.MainApp : AppPageNames.LogIn);
    }

    public void Receive(NavigateToPageMessage message)
    {
        CurrentView = _pageFactory.GetPageViewModel(message.PageName);
    }
}

public record NavigateToPageMessage(AppPageNames PageName);