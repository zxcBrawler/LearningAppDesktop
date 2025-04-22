using System;

namespace LearningApp.Models.Dto.Response;

public class PronunciationResponseDto
{
    public Uri AudioLink { get; set; }
    public string Pronunciation { get; set; }
}