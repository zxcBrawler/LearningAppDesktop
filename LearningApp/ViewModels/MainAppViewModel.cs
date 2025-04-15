using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Factories;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Utils.ImageControl;
using UserStateService = LearningApp.Utils.StateService.UserStateService;

namespace LearningApp.ViewModels;

public partial class MainAppViewModel : PageViewModel
{
    #region Services

    private readonly IAuthorizationService _authorizationService;
    private readonly PageFactory _pageFactory;
    [ObservableProperty] private UserStateService _userState;

    #endregion

    #region Observable Properties

    [ObservableProperty] private bool _isPaneOpen;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHomePageActive))]
    [NotifyPropertyChangedFor(nameof(IsCoursesPageActive))]
    [NotifyPropertyChangedFor(nameof(IsSettingsPageActive))]
    [NotifyPropertyChangedFor(nameof(IsDictionariesPageActive))]
    [NotifyPropertyChangedFor(nameof(IsProfilePageActive))]
    [NotifyPropertyChangedFor(nameof(IsWordSearchPageActive))]
    [NotifyPropertyChangedFor(nameof(IsStatisticsPageActive))]
    [NotifyPropertyChangedFor(nameof(IsStatisticsPageActive))]
    private PageViewModel _currentTabView;

    #endregion

    public MainAppViewModel(PageFactory pageFactory, IAuthorizationService authorizationService,
        UserStateService userState)
    {
        _pageFactory = pageFactory;
        _authorizationService = authorizationService;
        PageName = AppPageNames.MainApp;
        IsActive = true;
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Home);
        _userState = userState;
        LoadProfile().ConfigureAwait(false);
    }

    [RelayCommand]
    private void OpenPane() => IsPaneOpen = !IsPaneOpen;


    [RelayCommand]
    private async Task LogOut()
    {
        await _authorizationService.LogOut();
        UserState.LogOut();
        ImageCache.ClearCache();
        WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.LogIn));
    }

    private async Task LoadProfile()
    {
        await UserState.ReloadUserAsync().ConfigureAwait(false);
    }

    #region Navigation commands

    [RelayCommand]
    private void NavigateToHomePage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Home);

    [RelayCommand]
    private void NavigateToCoursesPage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Courses);

    [RelayCommand]
    private void NavigateToSettingsPage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Settings);

    [RelayCommand]
    private void NavigateToDictionariesPage() =>
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Dictionaries);

    [RelayCommand]
    private void NavigateToProfilePage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Profile);

    [RelayCommand]
    private void NavigateToWordSearchPage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Words);

    [RelayCommand]
    private void NavigateToStatisticsPage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Statistics);

    #endregion

    #region Boolean properties

    public bool IsHomePageActive => CurrentTabView.PageName == AppPageNames.Home;
    public bool IsCoursesPageActive => CurrentTabView.PageName == AppPageNames.Courses;
    public bool IsSettingsPageActive => CurrentTabView.PageName == AppPageNames.Settings;
    public bool IsDictionariesPageActive => CurrentTabView.PageName == AppPageNames.Dictionaries;
    public bool IsProfilePageActive => CurrentTabView.PageName == AppPageNames.Profile;
    public bool IsWordSearchPageActive => CurrentTabView.PageName == AppPageNames.Words;
    public bool IsStatisticsPageActive => CurrentTabView.PageName == AppPageNames.Statistics;

    #endregion
}