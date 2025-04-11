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
    private readonly INavigationFactory _navigationFactory;
    private readonly Func<Window> _mainWindowGetter;

    public ProfileViewModel(UserStateService userState, INavigationFactory navigationFactory,
        Func<Window> mainWindowGetter)
    {
        PageName = AppPageNames.Profile;
        _userState = userState;
        _navigationFactory = navigationFactory;
        _mainWindowGetter = mainWindowGetter;
    }

    [RelayCommand]
    private async Task UpdateProfileData()
    {
        var dialog = _navigationFactory.CreateChangeProfileView();
        await dialog.ShowDialog(_mainWindowGetter());
    }

    [RelayCommand]
    private async Task UpdatePassword()
    {
        // open ChangePasswordView here
    }
}