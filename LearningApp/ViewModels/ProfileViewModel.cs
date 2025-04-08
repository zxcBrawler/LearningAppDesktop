using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models.Dto.Request;
using LearningApp.Utils;
using LearningApp.Utils.Enum;

namespace LearningApp.ViewModels;

public partial class ProfileViewModel : PageViewModel
{
    [ObservableProperty] private UserStateService _userState;

    public ProfileViewModel(UserStateService userState)
    {
        PageName = AppPageNames.Profile;
        _userState = userState;
    }

    [RelayCommand]
    private async Task UpdateProfileData()
    {
        await UserState.ChangeProfileData(new UpdateProfileRequestDto()
        {
            Email = "admin@gmail.com",
            ProfilePicture =
                "https://mir-s3-cdn-cf.behance.net/projects/404/e28c10126211171.63ddd18ace32f.png",
            Username = "qwertyuser123"
        });
        Console.WriteLine("updating.....");
    }

    [RelayCommand]
    private async Task UpdatePassword()
    {
        //await _userState.UpdateUserPassword();
        Console.WriteLine("updating password.....");
    }
}