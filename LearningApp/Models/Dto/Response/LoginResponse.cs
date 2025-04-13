using System;
using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Response;

/// <summary>
/// 
/// </summary>
public class LoginResponse
{
    [JsonPropertyName("access_token")] public required string AccessToken { get; set; }

    [JsonPropertyName("access_token_expiry_date")]
    public DateTime AccessTokenExpiryDate { get; init; }

    [JsonPropertyName("refresh_token")] public required string RefreshToken { get; init; }

    [JsonPropertyName("refresh_token_expiry_date")]
    public DateTime RefreshTokenExpiryDate { get; init; }

    public bool IsAccessTokenValid => !string.IsNullOrEmpty(AccessToken) && AccessTokenExpiryDate > DateTime.UtcNow;
    public bool IsRefreshTokenValid => !string.IsNullOrEmpty(RefreshToken) && RefreshTokenExpiryDate > DateTime.UtcNow;
}