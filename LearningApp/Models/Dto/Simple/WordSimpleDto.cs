using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

public class WordSimpleDto
{
    [JsonPropertyName("id_word")] public int Id { get; init; }
    [JsonPropertyName("word_value")] public string? WordValue { get; set; }
    [JsonPropertyName("word_definition")] public string? WordDefinition { get; set; }

    [JsonPropertyName("word_pronunciation")]
    public string? WordPronunciation { get; set; }

    [JsonPropertyName("usage_examples")] public string? UsageExamples { get; set; }
    [JsonPropertyName("part_of_speech")] public List<PartOfSpeechEnum> PartOfSpeech { get; set; }
    [JsonPropertyName("language_level")] public string? LanguageLevel { get; set; }
}