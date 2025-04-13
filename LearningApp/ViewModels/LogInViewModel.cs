using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Models.Dto.Request;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class LogInViewModel : PageViewModel
{
    private bool _isPasswordVisible;

    private readonly IAuthorizationService _authorizationService;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password = string.Empty;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _email = string.Empty;

    public LogInViewModel(IAuthorizationService authorizationService)
    {
        PageName = AppPageNames.LogIn;
        _authorizationService = authorizationService;
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
        LoginRequestDto loginRequestDto = new()
        {
            Email = Email,
            Password = Password
        };
        var response = await _authorizationService.Login(loginRequestDto);
        if (response.IsSuccess)
        {
            WeakReferenceMessenger.Default.Send(new NavigateToPageMessage(AppPageNames.MainApp));
            Console.WriteLine(response.StatusCode);
        }
        else

        {
            Console.WriteLine(response.ErrorMessage);
        }
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
    private bool CanLogin => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && IsEmailValid;
    private bool IsEmailValid => IsValidEmail(Email);

    private static bool IsValidEmail(string? email)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    #endregion
}