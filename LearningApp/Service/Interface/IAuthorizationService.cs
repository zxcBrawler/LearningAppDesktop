using System.Threading.Tasks;
using LearningApp.DataSource;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;

namespace LearningApp.Service.Interface;

public interface IAuthorizationService
{
    Task<DataState<string>> Register(RegisterRequestDto registerRequestDto);
    Task<DataState<LoginResponse>> Login(LoginRequestDto loginRequestDto);
}