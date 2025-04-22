using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.WindowFactory;
using LearningApp.Models.Dto.Response;
using LearningApp.Utils.Enum;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class WordSearchViewModel : PageViewModel
{
    private readonly Func<Window> _mainWindowGetter;
    private readonly IWindowFactory _windowFactory;
    private CancellationTokenSource _searchTokenSource;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(IsSearching))]
    private string _requestWord = string.Empty;

    [ObservableProperty] private bool _isSearching;

    [ObservableProperty] private WordStateService _wordStateService;

    public WordSearchViewModel(WordStateService wordStateService, Func<Window> mainWindowGetter,
        IWindowFactory windowFactory)
    {
        _wordStateService = wordStateService;
        _mainWindowGetter = mainWindowGetter;
        _windowFactory = windowFactory;
        PageName = AppPageNames.Words;
        WordStateService.CurrentWordList = [];
        WordStateService.SelectedWord = null;
    }


    partial void OnRequestWordChanged(string value)
    {
        _searchTokenSource?.Cancel();
        _searchTokenSource = new CancellationTokenSource();
        if (!string.IsNullOrWhiteSpace(value))
        {
            DebounceSearch(_searchTokenSource.Token).ConfigureAwait(false);
        }
        else
        {
            WordStateService.CurrentWordList = [];
        }
    }

    private async Task DebounceSearch(CancellationToken token)
    {
        try
        {
            await Task.Delay(300, token);

            if (!token.IsCancellationRequested)
            {
                await SearchWord();
            }
        }
        catch (TaskCanceledException)
        {
        }
    }

    [RelayCommand]
    private async Task SearchWord()
    {
        if (string.IsNullOrWhiteSpace(RequestWord))
        {
            WordStateService.CurrentWordList = [];
            return;
        }

        try
        {
            IsSearching = true;
            await WordStateService.SearchWord(RequestWord);
        }
        finally
        {
            IsSearching = false;
        }
    }

    [RelayCommand]
    private async Task OpenWordDetails(MerriamWebsterResponseDto response)
    {
        WordStateService.SelectedWord = response;
        WordStateService.IsPronunciationAvailable = response.Pronunciation != null;

        var window = _windowFactory.CreateWordDetailsWindow();
        await window.ShowDialog(_mainWindowGetter());
    }
}