using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models.Dto.Request;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class ChangeProfileDataViewModel(UserStateService userState) : ViewModelBase
{
    [ObservableProperty] private UserStateService _userState = userState;
    
    [RelayCommand]
    private async Task UpdateProfileData()
    {
        await UserState.ChangeProfileData(new UpdateProfileRequestDto()
        {
            Email = UserState.CurrentUser.Email,
            ProfilePicture = UserState.CurrentUser.ProfilePicture,
            Username = UserState.CurrentUser.Username
        });
        Console.WriteLine("updating.....");
    }
}