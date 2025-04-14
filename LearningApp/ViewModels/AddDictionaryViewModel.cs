using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models.Dto.Request;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class AddDictionaryViewModel(UserStateService userStateService) : ViewModelBase
{
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(AddDictionaryCommand))]
    private string _dictionaryName = string.Empty;

    [ObservableProperty] private string? _imageUrl;
    [ObservableProperty] private UserStateService _userStateService = userStateService;

    [RelayCommand(CanExecute = nameof(CanAddNewDictionary))]
    private async Task AddDictionary()
    {
        await UserStateService.AddNewDictionary(new AddDictionaryRequestDto
        {
            DictionaryName = DictionaryName,
            ImageUrl = ImageUrl
        });
        DictionaryName = string.Empty;
        ImageUrl = string.Empty;
        // TODO: If response is successful show pop up dialog 
    }

    private bool CanAddNewDictionary => !string.IsNullOrEmpty(DictionaryName);
}