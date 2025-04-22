using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;

namespace LearningApp.Utils.StateService;

public partial class WordStateService(IWordService wordService) : ObservableObject
{
    [ObservableProperty] private MerriamWebsterResponseDto? _selectedWord;
    [ObservableProperty] private bool _isPronunciationAvailable;
    [ObservableProperty] private ObservableCollection<MerriamWebsterResponseDto>? _currentWordList = [];

    public async Task SearchWord(string requestWord)
    {
        var response = await wordService.GetWordFromDictionary(requestWord);
        if (response is { IsSuccess: true, Value: not null })
            CurrentWordList = new ObservableCollection<MerriamWebsterResponseDto>(response.Value);
    }
}