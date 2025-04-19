using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Models.Dto.Complex;
using LearningApp.Utils.Enum;
using CourseStateService = LearningApp.Utils.StateService.CourseStateService;

namespace LearningApp.ViewModels;

public partial class CoursesViewModel : PageViewModel
{
    private readonly Func<Window> _mainWindowGetter;
    private readonly IWindowFactory _windowFactory;

    [ObservableProperty] private CourseStateService _courseStateService;

    public CoursesViewModel(Func<Window> mainWindowGetter,
        IWindowFactory windowFactory, CourseStateService courseStateService)
    {
        PageName = AppPageNames.Courses;
        _windowFactory = windowFactory;
        _courseStateService = courseStateService;
        _mainWindowGetter = mainWindowGetter;
        OnWindowLoaded().ConfigureAwait(false);
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
        var window = _windowFactory.CreateCourseDetailsWindow();
        await window.ShowDialog(_mainWindowGetter());
    }
}