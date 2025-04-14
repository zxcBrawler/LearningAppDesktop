using System;
using LearningApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Factories.WindowViewModelFactoryImpl;

public class WindowViewModelFactory(IServiceProvider serviceProvider) : IWindowViewModelFactory
{
    public ExerciseViewModel CreateExerciseViewModel()
    {
        return serviceProvider.GetRequiredService<ExerciseViewModel>();
    }

    public CourseDetailsViewModel CreateCourseDetailsViewModel()
    {
        return serviceProvider.GetRequiredService<CourseDetailsViewModel>();
    }

    public ChangePasswordViewModel CreateChangePasswordViewModel()
    {
        return serviceProvider.GetRequiredService<ChangePasswordViewModel>();
    }

    public ChangeProfileDataViewModel CreateChangeProfileDataViewModel()
    {
        return serviceProvider.GetRequiredService<ChangeProfileDataViewModel>();
    }

    public AddDictionaryViewModel CreateAddDictionaryViewModel()
    {
        return serviceProvider.GetRequiredService<AddDictionaryViewModel>();
    }
}