using System;
using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

// TODO: Complete docs
/// <summary>
/// The user simple dto class
/// </summary>
public class UserSimpleDto
{
    /// <summary>
    /// 
    /// </summary>
    public long Id { get; init; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("profile_picture")]
    public string? ProfilePicture { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("registration_date")]
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("role")]
    public RoleSimpleDto? Role { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("current_xp")]
    public int CurrentXp { get; set; }

    [JsonPropertyName("current_streak")] public int CurrentStreak { get; set; }
}