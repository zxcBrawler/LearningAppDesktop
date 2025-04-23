using System.Threading.Tasks;
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


    public HomeViewModel(UserStateService userStateService, IWindowFactory windowFactory,
        CourseStateService courseStateService)
    {
        PageName = AppPageNames.Home;
        _userStateService = userStateService;
        _windowFactory = windowFactory;
        _courseStateService = courseStateService;
    }

    [RelayCommand]
    private async Task OnWindowLoaded()
    {
        await UserStateService.LoadUserCourses().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task ContinueCourse(long courseId)
    {
        await UserStateService.LoadUserCourse(courseId);
        await CourseStateService.GetCourseById(courseId);
        _windowFactory.Show(AppWindowNames.ExerciseWindow);
    }
}