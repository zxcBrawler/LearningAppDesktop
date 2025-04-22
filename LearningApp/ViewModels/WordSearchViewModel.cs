using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class WordSearchViewModel : PageViewModel
{
    private readonly IWordService _wordService;
    [ObservableProperty] private string _requestWord = string.Empty;

    [ObservableProperty] private ObservableCollection<MerriamWebsterResponseDto>? _currentWordList = [];

    public WordSearchViewModel(IWordService wordService)
    {
        _wordService = wordService;
        PageName = AppPageNames.Words;
    }


    [RelayCommand]
    private async Task SearchWord()
    {
        var result = await _wordService.GetWordFromDictionary(RequestWord);
        CurrentWordList = new ObservableCollection<MerriamWebsterResponseDto>(result.Value);
    }

    [RelayCommand]
    private void OpenWordDetails(MerriamWebsterResponseDto response)
    {
        Console.WriteLine(response.Headword);
    }
}