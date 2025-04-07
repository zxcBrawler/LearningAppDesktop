using System;
using Avalonia.Controls;
using LearningApp.Utils.ImageControl;

namespace LearningApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        ImageCache.ClearCache();
    }
}