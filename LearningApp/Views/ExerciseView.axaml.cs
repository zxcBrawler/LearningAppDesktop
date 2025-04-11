using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using AvaloniaDialogs.Views;

namespace LearningApp.Views;

public partial class ExerciseView : Window
{
    public ExerciseView()
    {
        InitializeComponent();
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var dialog = new TwofoldDialog()
            {
                Message = "Do you want to discard this lesson?",
                PositiveText = "Yes",
                NegativeText = "No",
                Width = 400,
                HorizontalButtonAlignment = HorizontalAlignment.Stretch,
            };
            var result = await dialog.ShowAsync();
            if (result is { HasValue: true, Value: true })
            {
                Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}