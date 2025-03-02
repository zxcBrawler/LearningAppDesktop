using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Utils;

namespace LearningApp.ViewModels;

public partial class SignUpViewModel : PageViewModel
{
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string? _email;

    private bool _isPasswordVisible;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string? _password;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string? _repeatPassword;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string? _username;

    public SignUpViewModel()
    {
        PageName = AppPageNames.SignUp;
    }

    public bool IsPasswordVisible
    {
        get => _isPasswordVisible;
        set
        {
            if (SetProperty(ref _isPasswordVisible, value)) OnPropertyChanged(nameof(ImagePath));
        }
    }

    public string ImagePath => IsPasswordVisible ? "/Assets/Icons/eye-off.svg" : "/Assets/Icons/eye.svg";

    private bool CanSignUp => !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RepeatPassword) &&
                              !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email);

    [RelayCommand(CanExecute = nameof(CanSignUp))]
    private async Task SignUp()
    {
        await Task.Delay(TimeSpan.FromSeconds(3));
        NavigateToLogIn();
    }

    [RelayCommand]
    private void TogglePasswordVisibility()
    {
        IsPasswordVisible = !IsPasswordVisible;
    }

    [RelayCommand]
    public void NavigateToLogIn()
    {
        WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.LogIn));
    }
}