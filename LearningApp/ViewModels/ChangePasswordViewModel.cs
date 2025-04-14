using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Models.Dto.Request;
using LearningApp.Utils.StateService;

namespace LearningApp.ViewModels;

public partial class ChangePasswordViewModel(UserStateService userState) : ViewModelBase
{
    [ObservableProperty] private UserStateService _userState = userState;
    [ObservableProperty] private string _oldPassword = string.Empty;
    [ObservableProperty] private string _newPassword = string.Empty;

    [RelayCommand]
    private async Task UpdatePassword()
    {
        await UserState.UpdateUserPassword(new UpdatePasswordRequestDto
        {
            OldPassword = OldPassword,
            NewPassword = NewPassword
        });
        // TODO: If response is successful show pop up dialog 
    }
}