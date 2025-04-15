using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models.Dto.Complex;
using LearningApp.Service.Interface;

namespace LearningApp.Utils.StateService;

public partial class CourseStateService(ICourseService courseService) : ObservableObject
{
    [ObservableProperty] private CourseComplexDto? _course;
    [ObservableProperty] private ObservableCollection<CourseComplexDto>? _availableCourses;

    public async Task LoadCourses()
    {
        var response = await courseService.GetOtherCourses();
        if (response is { IsSuccess: true, Value: not null })
            AvailableCourses = new ObservableCollection<CourseComplexDto>(response.Value);
    }

    public async Task GetCourseById(long courseId)
    {
        var response = await courseService.GetCourse(courseId);
        if (response is { IsSuccess: true, Value: not null })
            Course = response.Value;
    }

    public void LogOut()
    {
        AvailableCourses = null;
        Course = null;
    }
}