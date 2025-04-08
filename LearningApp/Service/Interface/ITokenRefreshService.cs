using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;

namespace LearningApp.Service.Interface;

public interface ITokenRefreshService
{
    Task<DataState<TokenResponse>> RefreshTokenAsync(RefreshTokenRequestDto request);
    Task<DataState<LoginResponse>> UpdateTokensAsync(RefreshTokenRequestDto request);
}