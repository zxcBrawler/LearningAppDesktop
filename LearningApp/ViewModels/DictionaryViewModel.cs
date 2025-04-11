using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class DictionaryViewModel : PageViewModel
{
    [ObservableProperty] private ObservableCollection<DictionarySimpleDto>? _items;
    [ObservableProperty] private UserStateService _userStateService;

    public DictionaryViewModel(UserStateService userStateService)
    {
        _userStateService = userStateService;
        PageName = AppPageNames.Dictionaries;

        Task.Run(async () => await GetDictionariesAsync());
    }

    private async Task GetDictionariesAsync()
    {
        await UserStateService.GetUserDictionaries();
        Items = UserStateService.UserDictionaries;
    }

    [RelayCommand]
    private async Task OpenDictionary(int id)
    {
        var result = await UserStateService.GetUserDictionaryById(id);
        foreach (var word in result.Words)
        {
            Console.WriteLine(word.WordValue);
        }
    }
}