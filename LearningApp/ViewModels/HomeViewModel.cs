using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Utils.Enum;
using LearningApp.Utils.StateService;
using UserStateService = LearningApp.Utils.StateService.UserStateService;

namespace LearningApp.ViewModels;

public partial class HomeViewModel : PageViewModel
{
    [ObservableProperty] private UserStateService _userStateService;
    [ObservableProperty] private CourseStateService _courseStateService;
    private readonly IWindowFactory _windowFactory;
    private readonly Func<Window> _mainWindowGetter;


    public HomeViewModel(UserStateService userStateService, IWindowFactory windowFactory, Func<Window> mainWindowGetter,
        CourseStateService courseStateService)
    {
        PageName = AppPageNames.Home;
        _userStateService = userStateService;
        _windowFactory = windowFactory;
        _mainWindowGetter = mainWindowGetter;
        _courseStateService = courseStateService;
        GetCoursesAsync().ConfigureAwait(false);
    }

    private async Task GetCoursesAsync()
    {
        await UserStateService.LoadUserCourses().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task ContinueCourse(long courseId)
    {
        await UserStateService.LoadUserCourse(courseId);
        await CourseStateService.GetCourseById(courseId);
        var exerciseDetailsWindow = _windowFactory.CreateExerciseDetailsWindow();
        await exerciseDetailsWindow.ShowDialog(_mainWindowGetter());
    }
}