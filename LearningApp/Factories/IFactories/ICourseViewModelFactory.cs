using LearningApp.ViewModels;

namespace LearningApp.Factories.IFactories;

public interface ICourseViewModelFactory
{
    CourseDetailsViewModel Create();
}