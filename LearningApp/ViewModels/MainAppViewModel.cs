using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Factories;
using LearningApp.Service.Interface;
using LearningApp.Utils;
using LearningApp.Utils.Enum;
using LearningApp.Utils.ImageControl;
using LearningApp.Utils.Settings;

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
        Task.Run(async () => await LoadProfile());
    }

    [RelayCommand]
    private void OpenPane() => IsPaneOpen = !IsPaneOpen;


    [RelayCommand]
    private async Task LogOut()
    {
        await _authorizationService.LogOut();
        _userState.LogOut();
        ImageCache.ClearCache();
        SettingsManager.ResetSettings();
        WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.LogIn));
    }

    private async Task LoadProfile()
    {
        await _userState.ReloadUserAsync();
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

    #endregion

    #region Boolean properties

    public bool IsHomePageActive => CurrentTabView.PageName == AppPageNames.Home;
    public bool IsCoursesPageActive => CurrentTabView.PageName == AppPageNames.Courses;
    public bool IsSettingsPageActive => CurrentTabView.PageName == AppPageNames.Settings;

    #endregion
}