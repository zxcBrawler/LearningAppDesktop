using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Utils.StateService;
using LibVLCSharp.Shared;

namespace LearningApp.ViewModels;

public partial class WordDetailsViewModel : ViewModelBase, IDisposable
{
    [ObservableProperty] private WordStateService _wordStateService;


    private readonly LibVLC _libVlc = new();
    private MediaPlayer MediaPlayer { get; }

    public WordDetailsViewModel(WordStateService wordStateService)
    {
        _wordStateService = wordStateService;
        MediaPlayer = new MediaPlayer(_libVlc);
    }

    [RelayCommand]
    private void Play()
    {
        using var media = new Media(_libVlc, WordStateService.SelectedWord.Pronunciation.AudioLink);
        MediaPlayer.Play(media);
    }


    public void Dispose()
    {
        _libVlc.Dispose();
        MediaPlayer.Dispose();
    }
}