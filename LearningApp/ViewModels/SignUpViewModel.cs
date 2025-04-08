﻿using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Layout;
using AvaloniaDialogs.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DialogHostAvalonia;
using LearningApp.Models.Dto.Request;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Views.CustomDialog;

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

    private readonly IAuthorizationService _authorizationService;


    public SignUpViewModel(IAuthorizationService authorizationService)
    {
        PageName = AppPageNames.SignUp;
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

    public string ImagePath => IsPasswordVisible ? "/Assets/Icons/eye-off.svg" : "/Assets/Icons/eye.svg";

    private bool CanSignUp => !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RepeatPassword) &&
                              !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email);

    [RelayCommand(CanExecute = nameof(CanSignUp))]
    private async Task SignUp()
    {
        var response = await _authorizationService.Register(new RegisterRequestDto()
        {
            Email = Email,
            Username = Username,
            Password = Password
        });

        var baseDialog = new CustomPopUpDialog()
        {
            Message = (response.IsSuccess
                ? $"We have sent you an email to {Email}. Please check your inbox."
                : response.ErrorMessage) ?? string.Empty,
            ButtonText = "Got it!",
            HorizontalButtonAlignment = HorizontalAlignment.Stretch,
            HorizontalContentAlignment = HorizontalAlignment.Center,
        };
        await baseDialog.ShowAsync();
        if (response.IsSuccess)
        {
            NavigateToLogIn();
        }
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