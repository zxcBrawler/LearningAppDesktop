using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using LearningApp.ViewModels;

namespace LearningApp.Views;

public partial class DictionaryView : UserControl
{
    public DictionaryView()
    {
        InitializeComponent();
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
    }

    private void DragOver(object? sender, DragEventArgs e)
    {
    }

    private void Drop(object? sender, DragEventArgs e)
    {
    }
}