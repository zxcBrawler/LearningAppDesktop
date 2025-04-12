using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Simple;
using LearningApp.Service.Interface;
using Refit;

namespace LearningApp.Service;

public class DictionaryService(IApiInterface apiInterface) : IDictionaryService
{
    public async Task<DataState<List<DictionarySimpleDto>>> GetUserDictionaries()
    {
        try
        {
            var result = await apiInterface.GetUserDictionaries();
            return DataState<List<DictionarySimpleDto>>.Success(result, 200);
        }
        catch (ApiException e)
        {
            return DataState<List<DictionarySimpleDto>>.Failure(e.Content, 404);
        }
    }

    public async Task<DataState<DictionarySimpleDto?>> GetUserDictionaryById(int dictionaryId)
    {
        try
        {
            var result = await apiInterface.GetUserDictionaryById(dictionaryId);
            return DataState<DictionarySimpleDto?>.Success(result, 200);
        }
        catch (ApiException e)
        {
            return DataState<DictionarySimpleDto?>.Failure(e.Content, 404);
        }
    }
}