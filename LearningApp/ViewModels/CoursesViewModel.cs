using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Models.Dto.Complex;
using LearningApp.Utils.Enum;
using CourseStateService = LearningApp.Utils.StateService.CourseStateService;

namespace LearningApp.ViewModels;

public partial class CoursesViewModel : PageViewModel
{
    private readonly IWindowFactory _windowFactory;

    [ObservableProperty] private CourseStateService _courseStateService;

    public CoursesViewModel(IWindowFactory windowFactory, CourseStateService courseStateService)
    {
        PageName = AppPageNames.Courses;
        _windowFactory = windowFactory;
        _courseStateService = courseStateService;
    }

    [RelayCommand]
    private async Task OnWindowLoaded()
    {
        await CourseStateService.LoadCourses().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task OpenPopUpCourseDetails(CourseComplexDto course)
    {
        await CourseStateService.GetCourseById(course.Id);
        _windowFactory.Show(AppWindowNames.CourseDetails);
        //await window.ShowDialog(_mainWindowGetter());
    }
}