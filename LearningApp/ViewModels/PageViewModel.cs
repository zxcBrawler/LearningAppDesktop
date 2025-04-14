using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Utils.Enum;
using LearningApp.Utils.LocalizationManager;

namespace LearningApp.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private AppPageNames _pageName;

    public string LocalizedPageName => GetLocalizedPageName();

    private string GetLocalizedPageName()
    {
        var fieldInfo = PageName.GetType().GetField(PageName.ToString());
        var attribute = fieldInfo?.GetCustomAttribute<LocalizedDescriptionAttribute>();
        return attribute?.Description ?? PageName.ToString();
    }

    protected PageViewModel()
    {
        LocalizationManager.LanguageChanged += (_, _) => { OnPropertyChanged(nameof(LocalizedPageName)); };
    }
}