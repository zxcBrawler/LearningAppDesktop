﻿using Avalonia.Controls;
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
}