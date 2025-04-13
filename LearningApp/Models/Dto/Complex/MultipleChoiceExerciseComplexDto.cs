using System.Collections.Generic;
using System.Text.Json.Serialization;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Models.Dto.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The multiple choice exercise complex dto class
    /// </summary>
    /// <seealso cref="MultipleChoiceExerciseSimpleDto"/>
    public class MultipleChoiceExerciseComplexDto : MultipleChoiceExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("options")]
        public List<OptionSimpleDto> Options { get; set; } = [];
    }
}