using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Utils.Enum;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class DictionaryViewModel : PageViewModel
{
    [ObservableProperty] private UserStateService _userStateService;
    private readonly IWindowFactory _windowFactory;

    public DictionaryViewModel(UserStateService userStateService, IWindowFactory windowFactory)
    {
        _userStateService = userStateService;
        _windowFactory = windowFactory;
        PageName = AppPageNames.Dictionaries;
    }

    [RelayCommand]
    private async Task OnWindowLoaded()
    {
        await UserStateService.GetUserDictionaries().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task OpenDictionary(int id)
    {
        await UserStateService.GetUserDictionaryById(id);
        _windowFactory.Show(AppWindowNames.DictionaryDetailsWindow);
    }

    [RelayCommand]
    private async Task OpenAddDictionaryDialog()
    {
        await _windowFactory.ShowDialog<bool>(AppWindowNames.AddDictionaryWindow);
    }

    [RelayCommand]
    private async Task DeleteDictionary(int id)
    {
        await UserStateService.DeleteDictionary(id);
    }
}