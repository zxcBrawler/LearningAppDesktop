using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class DictionaryViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<string>? _items;

    public DictionaryViewModel()
    {
        Items =
        [
            "Dictionary Title", "Dictionary Title", "Dictionary Title", "Dictionary Title", "Dictionary Title",
            "Dictionary Title", "Dictionary Title", "Dictionary Title", "Dictionary Title", "Dictionary Title",
            "Dictionary Title", "Dictionary Title", "Dictionary Title", "Dictionary Title"
        ];
        PageName = AppPageNames.Dictionaries;
    }


    [RelayCommand]
    private void OpenDictionary()
    {
    }
}