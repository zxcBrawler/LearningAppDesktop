using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class DictionaryDetailsViewModel : ViewModelBase
{
    [ObservableProperty] private UserStateService _userStateService;

    public DictionaryDetailsViewModel(UserStateService userStateService)
    {
        _userStateService = userStateService;
    }

    [RelayCommand]
    private async Task DeleteFromDictionary(int wordId)
    {
        await UserStateService.DeleteWordFromDictionary(wordId);
    }
}