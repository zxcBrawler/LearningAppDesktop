using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaDialogs.Views;
using LearningApp.ViewModels;

namespace LearningApp.Views;

public partial class SignUpView : UserControl
{
    public SignUpView()
    {
        InitializeComponent();
    }

    private void TogglePasswordVisibility(object sender, RoutedEventArgs e)
    {
        if (DataContext is not SignUpViewModel viewModel) return;
        viewModel.IsPasswordVisible = !viewModel.IsPasswordVisible;
        PasswordField.PasswordChar = viewModel.IsPasswordVisible ? '\0' : '*';
    }
}