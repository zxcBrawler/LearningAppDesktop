using System;
using System.Collections.Generic;

namespace LearningApp.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? ProfilePicture { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string? Email { get; set; }
    public int Level { get; set; }
    public int CurrentXp { get; set; }
    public List<Course>? Courses { get; set; }
}