namespace LearningApp.Models.Dto.Request;

public class AddDictionaryRequestDto
{
    public required string DictionaryName { get; set; }
    public string? ImageUrl { get; set; }
}