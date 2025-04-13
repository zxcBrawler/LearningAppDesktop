using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Models;
using LearningApp.Models.Dto.Complex;
using LearningApp.Models.Dto.Response;
using LearningApp.Service;
using LearningApp.Service.Interface;
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
        _windowFactory = windowFactory;
        _courseStateService = courseStateService;
        _mainWindowGetter = mainWindowGetter;
        PageName = AppPageNames.Courses;
        Task.Run(async () => await GetCoursesAsync());
    }

    private async Task GetCoursesAsync()
    {
        await CourseStateService.LoadCourses();
    }

    [RelayCommand]
    private async Task OpenPopUpCourseDetails(CourseComplexDto course)
    {
        await CourseStateService.GetCourseById(course.Id);
        var window = _windowFactory.CreateCourseDetailsWindow();
        await window.ShowDialog(_mainWindowGetter());
    }
}