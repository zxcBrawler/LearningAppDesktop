using System;
using System.ComponentModel;
using Avalonia.Data;
using Avalonia.Markup.Xaml;

namespace LearningApp.Utils.LocalizationManager;

public class LocalizeExtension : MarkupExtension, INotifyPropertyChanged
{
    private readonly string _resourceKey;

    public LocalizeExtension(string resourceKey)
    {
        _resourceKey = resourceKey;
        LocalizationManager.LanguageChanged += (s, e) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
    }

    public string Value => LocalizationManager.GetString(_resourceKey);

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return new Binding
        {
            Source = this,
            Path = nameof(Value),
            Mode = BindingMode.OneWay
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}