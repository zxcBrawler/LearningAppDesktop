using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Factories;
using LearningApp.Service;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class MainAppViewModel : PageViewModel
{
    private readonly IAuthorizationService _authorizationService;
    [ObservableProperty] private bool _isPaneOpen;
    private readonly PageFactory _pageFactory;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHomePageActive))]
    [NotifyPropertyChangedFor(nameof(IsCoursesPageActive))]
    [NotifyPropertyChangedFor(nameof(IsSettingsPageActive))]
    private PageViewModel _currentTabView;

    public bool IsHomePageActive => CurrentTabView.PageName == AppPageNames.Home;
    public bool IsCoursesPageActive => CurrentTabView.PageName == AppPageNames.Courses;
    public bool IsSettingsPageActive => CurrentTabView.PageName == AppPageNames.Settings;

    public MainAppViewModel(PageFactory pageFactory, IAuthorizationService authorizationService)
    {
        _pageFactory = pageFactory;
        _authorizationService = authorizationService;
        PageName = AppPageNames.MainApp;
        IsActive = true;
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Home);
    }

    public MainAppViewModel()
    {
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
        WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.LogIn));
    }
}