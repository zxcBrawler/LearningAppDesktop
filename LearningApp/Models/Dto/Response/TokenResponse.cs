using System;

namespace LearningApp.Models.Dto.Response;

public class TokenResponse
{
    public required string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
}