using System;
using System.Globalization;
using System.Resources;
using LearningApp.Assets.Lang;

namespace LearningApp.Utils.LocalizationManager;

public static class LocalizationManager
{
    public static event EventHandler? LanguageChanged;

    public static void SetLanguage(string languageCode)
    {
        var culture = new CultureInfo(languageCode);
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        LanguageChanged?.Invoke(null, EventArgs.Empty);
    }

    public static string GetString(string resourceKey)
    {
        var resourceManager = new ResourceManager(typeof(Resources));
        return resourceManager.GetString(resourceKey, CultureInfo.CurrentUICulture) ?? $"[{resourceKey}]";
    }
}