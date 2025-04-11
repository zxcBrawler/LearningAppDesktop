using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Factories.IFactories;
using LearningApp.Models.Dto.Request;
using LearningApp.Utils;
using LearningApp.Utils.Enum;
using UserStateService = LearningApp.Utils.StateService.UserStateService;

namespace LearningApp.ViewModels;

public partial class ProfileViewModel : PageViewModel
{
    [ObservableProperty] private UserStateService _userState;
    private readonly IWindowFactory _windowFactory;
    private readonly Func<Window> _mainWindowGetter;

    public ProfileViewModel(UserStateService userState, IWindowFactory windowFactory,
        Func<Window> mainWindowGetter)
    {
        PageName = AppPageNames.Profile;
        _userState = userState;
        _windowFactory = windowFactory;
        _mainWindowGetter = mainWindowGetter;
    }

    [RelayCommand]
    private async Task UpdateProfileData()
    {
        var dialog = _windowFactory.CreateChangeProfileView();
        await dialog.ShowDialog(_mainWindowGetter());
    }

    [RelayCommand]
    private async Task UpdatePassword()
    {
        var dialog = _windowFactory.CreateChangePasswordView();
        await dialog.ShowDialog(_mainWindowGetter());
    }
}