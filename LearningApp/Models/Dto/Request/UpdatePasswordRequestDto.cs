namespace LearningApp.Models.Dto.Request;

/// <summary>
/// 
/// </summary>
public class UpdatePasswordRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public required string NewPassword { get; set; }

    public required string OldPassword { get; set; }
}