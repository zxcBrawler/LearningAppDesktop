using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories;
using LearningApp.Factories.IFactories;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils;
using LearningApp.Utils.Enum;
using LearningApp.Utils.TokenManagement;
using LearningApp.Views;
using CourseStateService = LearningApp.Utils.StateService.CourseStateService;

namespace LearningApp.ViewModels;

public partial class CoursesViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<Course> _items = [];
    private readonly Func<Window> _mainWindowGetter;

    private readonly CourseService _courseService;
    private readonly IWindowFactory _windowFactory;
    private readonly CourseStateService _courseStateService;

    public CoursesViewModel(Func<Window> mainWindowGetter, CourseService courseService,
        IWindowFactory windowFactory, CourseStateService courseStateService)
    {
        _courseService = courseService;
        _windowFactory = windowFactory;
        _courseStateService = courseStateService;
        _mainWindowGetter = mainWindowGetter;
        PageName = AppPageNames.Courses;
        Task.Run(async () => await GetCoursesAsync());
    }

    private async Task GetCoursesAsync()
    {
        var courses = await _courseService.GetCourses();
        Items = new ObservableCollection<Course>(courses);
    }

    [RelayCommand]
    private async Task OpenPopUpCourseDetails(Course course)
    {
        course = await _courseService.GetCourse(course.Id);
        _courseStateService.Course = course;
        var window = _windowFactory.CreateCourseDetailsWindow();
        await window.ShowDialog(_mainWindowGetter());
    }
}