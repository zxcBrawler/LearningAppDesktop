using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Response;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Service.Interface;

public interface IWordService
{
    Task<DataState<List<MerriamWebsterResponseDto>>> GetWordFromDictionary(string requestWord);
    Task<DataState<WordSimpleDto>> AddWord(MerriamWebsterResponseDto word, int dictionaryId);
}