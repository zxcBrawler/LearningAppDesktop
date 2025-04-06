namespace LearningApp.Models.Dto.Request;

/// <summary>
/// 
/// </summary>
public class LoginRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string Password { get; set; }
}