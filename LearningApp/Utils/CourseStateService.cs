using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models;

namespace LearningApp.Utils;

public partial class CourseStateService : ObservableObject
{
    [ObservableProperty] private Course? _course;
}