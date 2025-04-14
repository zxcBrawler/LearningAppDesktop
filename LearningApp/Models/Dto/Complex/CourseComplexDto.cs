using System.Collections.Generic;
using System.Text.Json.Serialization;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Models.Dto.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The course complex dto class
    /// </summary>
    /// <seealso cref="CourseSimpleDto"/>
    public class CourseComplexDto : CourseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("lesson")]
        public List<LessonComplexDto> Lesson { get; set; } = [];
    }
}