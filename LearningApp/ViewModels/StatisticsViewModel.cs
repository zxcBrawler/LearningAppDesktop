using CommunityToolkit.Mvvm.ComponentModel;
using LearningApp.Utils.Enum;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using ShimSkiaSharp;
using SKColor = SkiaSharp.SKColor;

namespace LearningApp.ViewModels;

public partial class StatisticsViewModel : PageViewModel

{

    public StatisticsViewModel()
    {
        PageName = AppPageNames.Statistics;
    }
    public Axis[] XAxes { get; set; } =
    [
        new Axis
        {
            Labels = ["Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"],
            LabelsRotation = 0,
            SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
            SeparatorsAtCenter = false,
            TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
            TicksAtCenter = true,
            ForceStepToMin = true,
            MinStep = 1
        }
    ];

    public ISeries[] Series { get; set; } =
    [
        new LineSeries<double>
        {
            Values = [2, 1, 3, 5, 3, 4, 6],
            Fill = null,
            GeometrySize = 20
        },
        new LineSeries<int, StarGeometry>
        {
            Values = [4, 2, 5, 2, 4, 5, 3],
            Fill = null,
            GeometrySize = 20,
        }
    ];

    public LabelVisual Title { get; set; } =
        new LabelVisual
        {
            Text = "My chart title",
            TextSize = 25,
            Padding = new LiveChartsCore.Drawing.Padding(15),
            Paint = new SolidColorPaint(new SKColor(255, 255, 255)),
        };
}