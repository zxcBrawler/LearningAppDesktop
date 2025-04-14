using System.Text.Json.Serialization;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Models.Dto.Complex
{
    // TODO: Complete doc
    /// <summary>
    /// The exercise complex dto class
    /// </summary>
    /// <seealso cref="ExerciseSimpleDto"/>
    public class ExerciseComplexDto : ExerciseSimpleDto
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("multiple_choice_exercise")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MultipleChoiceExerciseComplexDto? MultipleChoiceExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("text_answer_exercise")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TextAnswerExerciseSimpleDto? TextAnswerExercise { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("true_false_exercise")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TrueFalseExerciseSimpleDto? TrueFalseExercise { get; set; }
    }
}