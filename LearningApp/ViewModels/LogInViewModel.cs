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
    private string? _password;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _username;

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
            Email = _username,
            Password = _password
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
    private bool CanLogin => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

    #endregion
}