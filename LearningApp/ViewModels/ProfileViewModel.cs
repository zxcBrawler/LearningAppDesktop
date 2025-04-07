using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using LearningApp.Utils;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class ProfileViewModel : PageViewModel
{
    private readonly UserStateService _userState;

    [ObservableProperty] private UserSimpleDto? _currentUser;

    public ProfileViewModel(UserStateService userState)
    {
        PageName = AppPageNames.Profile;
        _userState = userState;
        if (_userState.CurrentUser != null) CurrentUser = _userState.CurrentUser;
    }


    [RelayCommand]
    private async Task UpdateProfileData()
    {
        Console.WriteLine("updating.....");
    }

    [RelayCommand]
    private async Task UpdatePassword()
    {
        Console.WriteLine("updating password.....");
    }
}