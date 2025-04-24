using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.DataSource;
using LearningApp.Utils.Enum;
using LearningApp.Utils.LocalizationManager;
using LearningApp.Utils.Settings;
using Refit;

namespace LearningApp.ViewModels;

public partial class SettingsViewModel : PageViewModel
{
    [ObservableProperty] private Settings? _settings;
    [ObservableProperty] private bool _isDailyRemindersEnabled;
    private readonly IApiInterface _apiInterface;

    public SettingsViewModel(IApiInterface apiInterface)
    {
        _apiInterface = apiInterface;
        PageName = AppPageNames.Settings;
        LoadSettings();
    }


    [RelayCommand]
    private void LoadSettings()
    {
        Settings = SettingsManager.LoadSettings();
        if (Settings == null) return;
        IsDailyRemindersEnabled = Settings.IsDailyRemindersEnabled;
    }

    [RelayCommand]
    private async Task SaveSettings()
    {
        Settings.IsDailyRemindersEnabled = IsDailyRemindersEnabled;
        if (IsDailyRemindersEnabled)
        {
            await SaveNotificationsDateTime(Settings.SelectedTime);
        }
        else
        {
            await StopNotifications();
        }

        SettingsManager.SaveSettings(Settings);
        Settings = SettingsManager.LoadSettings();
    }

    [RelayCommand]
    private void ChangeLanguage(int selectedIndex)
    {
        var languageCode = selectedIndex switch
        {
            0 => "en",
            1 => "ru",
            2 => "de",
            3 => "ja-jp",
            4 => "fr",
            _ => "en"
        };

        LocalizationManager.SetLanguage(languageCode);
        Settings.SelectedLanguageIndex = selectedIndex;
        Settings.SelectedLanguageCode = languageCode;
        SaveSettings();
    }

    [RelayCommand]
    private void ResetSettings()
    {
        SettingsManager.ResetSettings();
        LoadSettings();
    }

    [RelayCommand]
    private static void OpenPrivacyPolicy()
    {
        Process.Start(new ProcessStartInfo { FileName = "https://www.google.com", UseShellExecute = true });
    }

    [RelayCommand]
    private static void OpenTermsOfService()
    {
        Process.Start(new ProcessStartInfo { FileName = "https://docs.avaloniaui.net", UseShellExecute = true });
    }


    #region Api Calls

    private async Task SaveNotificationsDateTime(string dateTime)
    {
        try
        {
            await _apiInterface.SetNotificationsDateTime(dateTime);
        }
        catch (ApiException e)
        {
            Console.WriteLine(e.Content);
        }
    }

    private async Task StopNotifications()
    {
        try
        {
            await _apiInterface.StopNotifications();
        }
        catch (ApiException e)
        {
            Console.WriteLine(e.Content);
        }
    }

    #endregion
}