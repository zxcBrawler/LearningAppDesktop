using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace LearningApp.Models.Dto.Simple;

public class WordSimpleDto
{
    [JsonPropertyName("id_word")] public int Id { get; init; }
    [JsonPropertyName("word_value")] public required string WordValue { get; set; }
    [JsonPropertyName("word_definition")] public required string WordDefinition { get; set; }

    [JsonPropertyName("word_pronunciation")]
    public string? WordPronunciation { get; set; }

    [JsonPropertyName("word_pronunciation_audio")]
    public string? WordPronunciationAudio { get; set; }

    [JsonPropertyName("usage_examples")] public string? UsageExamples { get; set; }
    [JsonPropertyName("part_of_speech")] public string? PartOfSpeech { get; set; }
    [JsonPropertyName("language_level")] public required string LanguageLevel { get; set; }

    public IEnumerable<string> Definitions =>
        WordDefinition?.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        ?? Enumerable.Empty<string>();
}