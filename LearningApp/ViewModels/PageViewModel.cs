using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty] private AppPageNames _pageName;
}