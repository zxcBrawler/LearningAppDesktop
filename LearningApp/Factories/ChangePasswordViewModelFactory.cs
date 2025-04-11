using System;
using LearningApp.Factories.IFactories;
using LearningApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Factories;

public class ChangePasswordViewModelFactory(IServiceProvider serviceProvider) : IChangePasswordViewModelFactory
{
    public ChangePasswordViewModel Create()
    {
        var vm = serviceProvider.GetRequiredService<ChangePasswordViewModel>();
        return vm;
    }
}