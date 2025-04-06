using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class HomeViewModel : PageViewModel
{
    #region ObservableProperties

    [ObservableProperty] private ObservableCollection<UserCourseSimpleDto>? _userCourses;
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
        var courses = await _courseService.GetUserCourses();
        UserCourses = new ObservableCollection<UserCourseSimpleDto>(courses.Value);
        IsLoading = false;
    }
}