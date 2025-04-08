using System;
using LearningApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Factories;

public class ExerciseViewModelFactory(IServiceProvider serviceProvider) : IExerciseViewModelFactory
{
    public ExerciseViewModel Create()
    {
        var vm = serviceProvider.GetRequiredService<ExerciseViewModel>();
        return vm;
    }
}