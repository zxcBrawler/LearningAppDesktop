using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class LogInViewModel : PageViewModel
{
    private bool _isPasswordVisible;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _password;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _username;

    public LogInViewModel()
    {
        PageName = AppPageNames.LogIn;
    }

    public bool IsPasswordVisible
    {
        get => _isPasswordVisible;
        set
        {
            if (SetProperty(ref _isPasswordVisible, value)) OnPropertyChanged(nameof(ImagePath));
        }
    }


    [RelayCommand(CanExecute = nameof(CanLogin))]
    private async Task Login()
    {
        await Task.Delay(TimeSpan.FromSeconds(1));
        WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.MainApp));
    }


    [RelayCommand]
    private void TogglePasswordVisibility()
    {
        IsPasswordVisible = !IsPasswordVisible;
    }

    [RelayCommand]
    public void NavigateToSignUp()
    {
        WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.SignUp));
    }

    #region Commands Handlers

    public string ImagePath => IsPasswordVisible ? "/Assets/Icons/eye-off.svg" : "/Assets/Icons/eye.svg";
    private bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

    #endregion
}