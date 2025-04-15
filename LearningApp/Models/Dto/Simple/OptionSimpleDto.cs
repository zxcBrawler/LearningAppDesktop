using CommunityToolkit.Mvvm.ComponentModel;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete docs
/// <summary>
/// The option simple dto class
/// </summary>
public partial class OptionSimpleDto : ObservableObject
{
    /// <summary>
    ///
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    ///
    /// </summary>
    public required string Text { get; init; }

    [ObservableProperty] private bool _isSelected;
}