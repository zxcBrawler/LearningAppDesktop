using System.Collections.ObjectModel;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories;
using LearningApp.Models;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class MainAppViewModel : PageViewModel
{
    
    private readonly PageFactory _pageFactory;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHomePageActive))]
    [NotifyPropertyChangedFor(nameof(IsCoursesPageActive))]
    [NotifyPropertyChangedFor(nameof(IsSettingsPageActive))]
    private PageViewModel _currentTabView;
    
    public bool IsHomePageActive => CurrentTabView.PageName == AppPageNames.Home;
    public bool IsCoursesPageActive => CurrentTabView.PageName == AppPageNames.Courses;
    public bool IsSettingsPageActive => CurrentTabView.PageName == AppPageNames.Settings;
    public MainAppViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        PageName = AppPageNames.MainApp;
        IsActive = true; 
        CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Courses);
    }

  
    [RelayCommand]
    private void NavigateToHomePage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Home);
    [RelayCommand]
    private void NavigateToCoursesPage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Courses);
    [RelayCommand]
    private void NavigateToSettingsPage() => CurrentTabView = _pageFactory.GetPageViewModel(AppPageNames.Settings);
}

