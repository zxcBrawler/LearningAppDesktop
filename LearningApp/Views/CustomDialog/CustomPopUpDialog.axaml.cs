using Avalonia.Interactivity;
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