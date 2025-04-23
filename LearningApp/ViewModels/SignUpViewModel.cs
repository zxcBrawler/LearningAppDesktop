using System.Threading.Tasks;
using Avalonia.Layout;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Models.Dto.Request;
using LearningApp.Service.Interface;
using LearningApp.Utils.Enum;
using LearningApp.Views.CustomDialog;

namespace LearningApp.ViewModels;

public partial class SignUpViewModel : PageViewModel
{
    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string _email = string.Empty;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string _password = string.Empty;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string _repeatPassword = string.Empty;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(SignUpCommand))]
    private string _username = string.Empty;

    private readonly IAuthorizationService _authorizationService;

    public SignUpViewModel(IAuthorizationService authorizationService)
    {
        PageName = AppPageNames.SignUp;
        _authorizationService = authorizationService;
    }

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(ImagePath))]
    private bool _isPasswordVisible;

    public string ImagePath => IsPasswordVisible ? "/Assets/Icons/eye-off.svg" : "/Assets/Icons/eye.svg";

    private bool CanSignUp => !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RepeatPassword) &&
                              !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Email);

    [RelayCommand(CanExecute = nameof(CanSignUp))]
    private async Task SignUp()
    {
        var response = await _authorizationService.Register(new RegisterRequestDto
        {
            Email = Email,
            Username = Username,
            Password = Password
        });

        var baseDialog = new CustomPopUpDialog
        {
            Message = (response.IsSuccess
                ? $"We have sent you an email to {Email}. Please check your inbox."
                : response.ErrorMessage) ?? string.Empty,
            ButtonText = "Got it!",
            HorizontalButtonAlignment = HorizontalAlignment.Stretch,
            HorizontalContentAlignment = HorizontalAlignment.Center
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