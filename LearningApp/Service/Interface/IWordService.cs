using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Response;

namespace LearningApp.Service.Interface;

public interface IWordService
{
    Task<DataState<List<MerriamWebsterResponseDto>>> GetWordFromDictionary(string requestWord);
}