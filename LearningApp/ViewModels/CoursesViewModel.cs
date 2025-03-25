using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models;
using LearningApp.Service;
using LearningApp.Utils;
using LearningApp.Views;

namespace LearningApp.ViewModels;

public partial class CoursesViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<Course> _items = [];
    private readonly Func<Window> _mainWindowGetter;

    private readonly CourseService _courseService;

    public CoursesViewModel(Func<Window> mainWindowGetter, CourseService courseService)
    {
        _courseService = courseService;
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
        var courseDetailsViewModel = new CourseDetailsViewModel(course, _mainWindowGetter);
        var courseDetailsView = new CourseDetailsView
        {
            DataContext = courseDetailsViewModel
        };

        await courseDetailsView.ShowDialog(_mainWindowGetter());
    }
}