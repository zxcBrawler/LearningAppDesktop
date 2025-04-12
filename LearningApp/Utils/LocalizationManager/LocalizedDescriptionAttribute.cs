using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace LearningApp.Utils.LocalizationManager;

public class LocalizedDescriptionAttribute(string resourceKey, Type resourceType) : DescriptionAttribute
{
    public override string Description
    {
        get
        {
            var manager = new ResourceManager(resourceType);
            return manager.GetString(resourceKey, CultureInfo.CurrentUICulture) ?? resourceKey;
        }
    }
}