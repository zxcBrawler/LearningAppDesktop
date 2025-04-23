using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Utils.StateService;
using LibVLCSharp.Shared;

namespace LearningApp.ViewModels;

public partial class WordDetailsViewModel : ViewModelBase, IDisposable
{
    [ObservableProperty] private WordStateService _wordStateService;
    [ObservableProperty] private UserStateService _userStateService;


    private readonly LibVLC _libVlc = new();
    private MediaPlayer MediaPlayer { get; }

    public WordDetailsViewModel(WordStateService wordStateService, UserStateService userStateService)
    {
        _wordStateService = wordStateService;
        _userStateService = userStateService;
        MediaPlayer = new MediaPlayer(_libVlc);
    }

    [RelayCommand]
    private void Play()
    {
        using var media = new Media(_libVlc, WordStateService.SelectedWord.Pronunciation.AudioLink);
        MediaPlayer.Play(media);
    }

    [RelayCommand]
    private async Task AddWordToDictionary(int dictionaryId)
    {
        await UserStateService.AddWord(WordStateService.SelectedWord, dictionaryId);
    }


    public void Dispose()
    {
        _libVlc.Dispose();
        MediaPlayer.Dispose();
    }
}