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

namespace LearningApp.ViewModels;

public partial class MainAppViewModel : PageViewModel
{
    private readonly IAuthorizationService _authorizationService;
    [ObservableProperty] private bool _isPaneOpen;
    private readonly PageFactory _pageFactory;
    private readonly IProfileService _profileService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHomePageActive))]
    [NotifyPropertyChangedFor(nameof(IsCoursesPageActive))]
    [NotifyPropertyChangedFor(nameof(IsSettingsPageActive))]
    private PageViewModel _currentTabView;

    [ObservableProperty] private string _userProfilePicture;

    private readonly UserStateService _userState;

    public bool IsHomePageActive => CurrentTabView.PageName == AppPageNames.Home;
    public bool IsCoursesPageActive => CurrentTabView.PageName == AppPageNames.Courses;
    public bool IsSettingsPageActive => CurrentTabView.PageName == AppPageNames.Settings;

    public MainAppViewModel(PageFactory pageFactory, IAuthorizationService authorizationService,
        IProfileService profileService, UserStateService userState)
    {
        _pageFactory = pageFactory;
        _authorizationService = authorizationService;
        _profileService = profileService;
        PageName = AppPageNames.MainApp;
        IsActive = true;
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Home);
        _userState = userState;
        Task.Run(async () => await LoadProfile());
    }


    [RelayCommand]
    private void NavigateToHomePage()
    {
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Home);
        //if (IsPaneOpen) OpenPane();
    }

    [RelayCommand]
    private void NavigateToCoursesPage()
    {
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Courses);
        //if (IsPaneOpen) OpenPane();
    }

    [RelayCommand]
    private void NavigateToSettingsPage()
    {
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Settings);
        //if (IsPaneOpen) OpenPane();
    }

    [RelayCommand]
    private void NavigateToDictionariesPage()
    {
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Dictionaries);
    }


    [RelayCommand]
    private void NavigateToProfilePage()
    {
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Profile);
    }

    [RelayCommand]
    private void OpenPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    [RelayCommand]
    private async Task LogOut()
    {
        await _authorizationService.LogOut();
        _userState.LogOut();
        ImageCache.ClearCache();
        WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.LogIn));
    }

    private async Task LoadProfile()
    {
        await _userState.ReloadUserAsync();
        UserProfilePicture = _userState.CurrentUser.ProfilePicture;
    }
}