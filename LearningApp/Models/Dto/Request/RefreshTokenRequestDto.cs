namespace LearningApp.Models.Dto.Request;

/// <summary>
/// 
/// </summary>
public class RefreshTokenRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public required string RefreshToken { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string OldAccessToken { get; set; }
}