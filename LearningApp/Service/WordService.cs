using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;
using Refit;

namespace LearningApp.Service;

public class WordService(IApiInterface apiInterface) : IWordService
{
    public async Task<DataState<List<MerriamWebsterResponseDto>>> GetWordFromDictionary(string requestWord)
    {
        try
        {
            var response = await apiInterface.GetWordFromDictionary(requestWord);
            return DataState<List<MerriamWebsterResponseDto>>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<List<MerriamWebsterResponseDto>>.Failure(e.Content, 500);
        }
    }
}