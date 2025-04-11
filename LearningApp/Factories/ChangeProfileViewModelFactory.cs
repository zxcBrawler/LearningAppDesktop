using System;
using LearningApp.Factories.IFactories;
using LearningApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Factories;

public class ChangeProfileViewModelFactory(IServiceProvider serviceProvider) : IChangeProfileViewModelFactory
{
    public ChangeProfileDataViewModel Create()
    {
        var vm = serviceProvider.GetRequiredService<ChangeProfileDataViewModel>();
        return vm;
    }
}