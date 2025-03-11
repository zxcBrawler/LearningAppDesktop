using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class HomeViewModel : PageViewModel
{
    #region ObservableProperties

    [ObservableProperty] private ObservableCollection<UserCourse>? _userCourses;
    [ObservableProperty] private bool _isLoading;

    #endregion

    private readonly CourseService _courseService;

    public HomeViewModel(CourseService courseService)
    {
        _courseService = courseService;
        PageName = AppPageNames.Home;
        Task.Run(async () => await GetCoursesAsync());
    }

    private async Task GetCoursesAsync()
    {
        IsLoading = true;
        var courses = await _courseService.GetUserCourses(1);
        UserCourses = new ObservableCollection<UserCourse>(courses);
        IsLoading = false;
    }
}