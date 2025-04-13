namespace LearningApp.Models.Dto.Request;

public class UpdateProfileRequestDto
{
    public required string Username { get; set; }

    public required string ProfilePicture { get; set; }
    public required string Email { get; set; }
}