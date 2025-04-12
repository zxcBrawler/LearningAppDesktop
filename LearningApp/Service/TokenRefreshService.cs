using System;
using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;

namespace LearningApp.Service;

public class TokenRefreshService(IApiInterface apiService) : ITokenRefreshService
{
    public async Task<DataState<TokenResponse>> RefreshTokenAsync(RefreshTokenRequestDto request)
    {
        try
        {
            var response = await apiService.RefreshToken(request);
            return DataState<TokenResponse>.Success(response, 200);
        }
        catch (Exception e)
        {
            return DataState<TokenResponse>.Failure("An unexpected error occurred during the login process.",
                500);
        }
    }

    public async Task<DataState<LoginResponse?>> UpdateTokensAsync(RefreshTokenRequestDto request)
    {
        try
        {
            var response = await apiService.UpdateAllTokens(request);
            return DataState<LoginResponse?>.Success(response, 200);
        }
        catch (Exception e)
        {
            return DataState<LoginResponse?>.Failure("An unexpected error occurred during the login process.",
                500);
        }
    }
}