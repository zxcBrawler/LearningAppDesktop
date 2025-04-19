using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using AvaloniaDialogs.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Models.Dto.Simple;
using LearningApp.Utils.Enum;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class DictionaryViewModel : PageViewModel
{
    [ObservableProperty] private UserStateService _userStateService;
    private readonly IWindowFactory _windowFactory;
    private readonly Func<Window> _mainWindowGetter;

    public DictionaryViewModel(UserStateService userStateService, IWindowFactory windowFactory,
        Func<Window> mainWindowGetter)
    {
        _userStateService = userStateService;
        _windowFactory = windowFactory;
        _mainWindowGetter = mainWindowGetter;
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
        var result = await UserStateService.GetUserDictionaryById(id);
        foreach (var word in result.Words)
        {
            Console.WriteLine(word.WordValue);
        }
    }

    [RelayCommand]
    private async Task OpenAddDictionaryDialog()
    {
        var dialog = _windowFactory.CreateAddDictionaryView();
        await dialog.ShowDialog(_mainWindowGetter());
    }

    [RelayCommand]
    private async Task DeleteDictionary(int id)
    {
        await UserStateService.DeleteDictionary(id);
    }
}