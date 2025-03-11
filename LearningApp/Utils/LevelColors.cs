using System.Collections.Generic;

namespace LearningApp.Utils;

public static class LevelColors
{
    public static Dictionary<string, string> ColorMap { get; } = new()
    {
        { "A1", "#007700" },
        { "A2", "#007700" },
        { "B1", "#eb9800" },
        { "B2", "#eb9800" },
        { "C1", "#b30000" }
    };
}