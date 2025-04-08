using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using AvaloniaDialogs.Views;

namespace LearningApp.Views.CustomDialog;

public partial class CustomPopUpDialog : SingleActionDialog
{
    public CustomPopUpDialog()
    {
        InitializeComponent();
    }

    private void ButtonConfirm_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}