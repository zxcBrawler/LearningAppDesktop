using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LearningApp.Utils.Enum;
using LearningApp.Utils.LocalizationManager;
using LearningApp.Utils.Settings;

namespace LearningApp.ViewModels;

public partial class SettingsViewModel : PageViewModel
{
    [ObservableProperty] private Settings? _settings;
    [ObservableProperty] private bool _isDailyRemindersEnabled;
    [ObservableProperty] private bool _isStreakRemindersEnabled;

    public SettingsViewModel()
    {
        PageName = AppPageNames.Settings;
        LoadSettings();
    }


    private void LoadSettings()
    {
        Settings = SettingsManager.LoadSettings();
        if (Settings == null) return;
        IsDailyRemindersEnabled = Settings.IsDailyRemindersEnabled;
        IsStreakRemindersEnabled = Settings.IsStreakRemindersEnabled;
    }

    [RelayCommand]
    private void SaveSettings()
    {
        if (Settings == null) return;
        Settings.IsDailyRemindersEnabled = IsDailyRemindersEnabled;
        Settings.IsStreakRemindersEnabled = IsStreakRemindersEnabled;
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
    private void OpenPrivacyPolicy()
    {
        Process.Start(new ProcessStartInfo { FileName = "https://www.google.com", UseShellExecute = true });
    }

    [RelayCommand]
    private void OpenTermsOfService()
    {
        Process.Start(new ProcessStartInfo { FileName = "https://docs.avaloniaui.net", UseShellExecute = true });
    }
}