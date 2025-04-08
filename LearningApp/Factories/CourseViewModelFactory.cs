using System;
using LearningApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Factories;

public class CourseViewModelFactory(IServiceProvider serviceProvider) : ICourseViewModelFactory
{
    public CourseDetailsViewModel Create()
    {
        var vm = serviceProvider.GetRequiredService<CourseDetailsViewModel>();
        return vm;
    }
}