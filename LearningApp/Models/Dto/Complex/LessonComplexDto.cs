using System.Collections.Generic;
using System.Text.Json.Serialization;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Models.Dto.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The lesson complex dto class
    /// </summary>
    /// <seealso cref="LessonSimpleDto"/>
    public class LessonComplexDto : LessonSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("exercises")]
        public List<ExerciseComplexDto>? Exercises { get; set; }
    }
}