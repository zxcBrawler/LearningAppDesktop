using System;
using System.IO;
using System.Threading.Tasks;
using LearningApp.DataSource;
using Newtonsoft.Json;
using Refit;

namespace LearningApp.Utils.Settings;

public class SettingsManager
{
    private static readonly string SettingsPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LearningApp",
            "settings.json");

    public static Settings? LoadSettings()
    {
        try
        {
            if (File.Exists(SettingsPath))
            {
                var json = File.ReadAllText(SettingsPath);
                return JsonConvert.DeserializeObject<Settings>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($@"Error loading settings: {ex.Message}");
        }

        return new Settings
        {
            SelectedThemeIndex = 0,
            IsDailyRemindersEnabled = false,
            SelectedTime = "00:00",
            SelectedDailyGoalIndex = 0,
            SelectedLanguageIndex = 0,
            SelectedLanguageCode = "en"
        };
    }

    public static void ResetSettings()
    {
        var defaultSettings = new Settings
        {
            SelectedThemeIndex = 0,
            IsDailyRemindersEnabled = false,
            SelectedTime = "00:00",
            SelectedDailyGoalIndex = 0,
            SelectedLanguageIndex = 0,
            SelectedLanguageCode = "en"
        };
        SaveSettings(defaultSettings);
    }


    public static void SaveSettings(Settings? settings)
    {
        try
        {
            var directoryPath = Path.GetDirectoryName(SettingsPath);

            if (!Directory.Exists(directoryPath))
                if (directoryPath != null)
                    Directory.CreateDirectory(directoryPath);

            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);

            File.WriteAllText(SettingsPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($@"Error saving settings: {ex.Message}");
        }
    }
}