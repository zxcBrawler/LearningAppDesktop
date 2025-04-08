using LearningApp.Models;
using LearningApp.ViewModels;

namespace LearningApp.Factories;

public interface ICourseViewModelFactory
{
    CourseDetailsViewModel Create();
}