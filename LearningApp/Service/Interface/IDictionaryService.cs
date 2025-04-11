using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Simple;

namespace LearningApp.Service.Interface;

public interface IDictionaryService
{
    Task<DataState<List<DictionarySimpleDto>>> GetUserDictionaries();
    Task<DataState<DictionarySimpleDto>> GetUserDictionaryById(int dictionaryId);
}