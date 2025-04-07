using System.Threading.Tasks;
using LearningApp.Models.Dto.Response;

namespace LearningApp.Utils.TokenManagement;

public interface ITokenStorage
{
    void SaveTokens(LoginResponse loginResponse);
    LoginResponse? LoadTokens();
    void DeleteTokens();
    public bool ValidateTokens();
}