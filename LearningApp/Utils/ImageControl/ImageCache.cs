using System.Collections.Concurrent;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace LearningApp.Utils.ImageControl;

public static class ImageCache
{
    private static readonly ConcurrentDictionary<string, Bitmap> Cache = new();
    private static readonly HttpClient HttpClient = new();

    public static async Task<Bitmap?> GetImageAsync(string url)
    {
        if (string.IsNullOrEmpty(url))
            return null;

        if (Cache.TryGetValue(url, out var cachedImage))
            return cachedImage;

        try
        {
            var bytes = await HttpClient.GetByteArrayAsync(url);
            using var stream = new MemoryStream(bytes);
            var bitmap = new Bitmap(stream);
            Cache[url] = bitmap;
            return bitmap;
        }
        catch
        {
            return null;
        }
    }

    public static void ClearCache()
    {
        foreach (var bitmap in Cache.Values)
            bitmap.Dispose();
        Cache.Clear();
    }
}