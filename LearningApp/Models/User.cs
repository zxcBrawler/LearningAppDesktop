using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace LearningApp.Models;

public class User
{
    public int Id { get; set; }
    [JsonPropertyName("username")] public string? Username { get; set; }
    [JsonPropertyName("profile_Picture")] public string? ProfilePicture { get; set; }

    [JsonPropertyName("registration_Date")]
    public DateTime RegistrationDate { get; set; }

    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("level")] public int Level { get; set; }
    [JsonPropertyName("current_XP")] public int CurrentXp { get; set; }
    public List<Course>? Courses { get; set; }
}