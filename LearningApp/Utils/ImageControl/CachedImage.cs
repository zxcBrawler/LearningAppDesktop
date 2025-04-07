using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace LearningApp.Utils.ImageControl;

public class CachedImage : Control
{
    public static readonly StyledProperty<Stretch> StretchProperty =
        AvaloniaProperty.Register<CachedImage, Stretch>(nameof(Stretch), Stretch.Uniform);

    public static readonly StyledProperty<string> SourceProperty =
        AvaloniaProperty.Register<CachedImage, string>(nameof(Source));

    public Stretch Stretch
    {
        get => GetValue(StretchProperty);
        set => SetValue(StretchProperty, value);
    }

    private Bitmap? _bitmap;

    public string Source
    {
        get => GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    static CachedImage()
    {
        SourceProperty.Changed.AddClassHandler<CachedImage>((x, e) => x.OnSourceChanged(e));
    }

    private async void OnSourceChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.NewValue is not string url) return;
        _bitmap = await ImageCache.GetImageAsync(url);
        InvalidateVisual();
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        if (_bitmap == null) return;

        var sourceRect = new Rect(0, 0, _bitmap.PixelSize.Width, _bitmap.PixelSize.Height);
        var destRect = CalculateDestRect(sourceRect.Size);

        context.DrawImage(_bitmap, sourceRect, destRect);
    }

    private Rect CalculateDestRect(Size imageSize)
    {
        return Stretch switch
        {
            Stretch.None => new Rect(0, 0, imageSize.Width, imageSize.Height),
            Stretch.Fill => new Rect(0, 0, Bounds.Width, Bounds.Height),
            Stretch.UniformToFill => CalculateUniformToFill(imageSize),
            _ => new Rect(0, 0, Bounds.Width, Bounds.Height)
        };
    }

    private Rect CalculateUniformToFill(Size imageSize)
    {
        var scale = Math.Max(Bounds.Width / imageSize.Width, Bounds.Height / imageSize.Height);
        var width = imageSize.Width * scale;
        var height = imageSize.Height * scale;
        var x = (Bounds.Width - width) / 2;
        var y = (Bounds.Height - height) / 2;
        return new Rect(x, y, width, height);
    }
}