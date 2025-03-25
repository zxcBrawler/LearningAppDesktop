using System;
using LearningApp.Utils;
using LearningApp.Utils.Enum;
using LearningApp.ViewModels;

namespace LearningApp.Factories;

public class PageFactory(Func<AppPageNames, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(AppPageNames pageName)
    {
        return factory.Invoke(pageName);
    }
}