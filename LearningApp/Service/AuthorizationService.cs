﻿using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;
using LearningApp.Utils.TokenManagement;
using Refit;

namespace LearningApp.Service;

public class AuthorizationService(IApiInterface apiService, ITokenStorage tokenStorage) : IAuthorizationService
{
    public async Task<DataState<string>> LogOut()
    {
        try
        {
            var response = await apiService.LogOut();
            tokenStorage.DeleteTokens();
            return DataState<string>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<string>.Failure(e.Content,
                500);
        }
    }

    public async Task<DataState<LoginResponse>> Login(LoginRequestDto loginRequestDto)
    {
        try
        {
            var response = await apiService.Login(loginRequestDto);

            tokenStorage.SaveTokens(response);
            return DataState<LoginResponse>.Success(response, 200);
        }
        catch (ApiException e)
        {
            return DataState<LoginResponse>.Failure(e.Content,
                404);
        }
    }

    public async Task<DataState<string>> Register(RegisterRequestDto registerRequestDto)
    {
        try
        {
            var response = await apiService.RegisterAsync(registerRequestDto);
            return DataState<string>.Success(response, 201);
        }
        catch (ApiException e)
        {
            return DataState<string>.Failure(e.Content,
                404);
        }
    }
}