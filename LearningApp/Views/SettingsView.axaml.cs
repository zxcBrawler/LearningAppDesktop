using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LearningApp.ViewModels;

namespace LearningApp.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is not ComboBox { DataContext: SettingsViewModel viewModel } comboBox) return;
        viewModel.ChangeLanguageCommand.Execute(comboBox.SelectedIndex);
    }

    private void SelectingItemsControlLang_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (sender is not ComboBox { DataContext: SettingsViewModel viewModel } comboBox) return;
    }
}