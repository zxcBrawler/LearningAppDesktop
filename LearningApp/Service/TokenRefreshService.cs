using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;
using Refit;

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
        catch (ApiException e)
        {
            return DataState<TokenResponse>.Failure(e.Content,
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
        catch (ApiException e)
        {
            return DataState<LoginResponse?>.Failure(e.Content,
                500);
        }
    }
}