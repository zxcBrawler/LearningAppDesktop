using LearningApp.ViewModels;

namespace LearningApp.Factories.WindowViewModelFactoryImpl;

public interface IWindowViewModelFactory
{
    ExerciseViewModel CreateExerciseViewModel();
    CourseDetailsViewModel CreateCourseDetailsViewModel();
    ChangePasswordViewModel CreateChangePasswordViewModel();
    ChangeProfileDataViewModel CreateChangeProfileDataViewModel();
}