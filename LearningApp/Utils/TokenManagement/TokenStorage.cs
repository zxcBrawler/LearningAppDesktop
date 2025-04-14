using System;
using System.IO;
using System.Runtime.Versioning;
using LearningApp.Models.Dto.Response;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace LearningApp.Utils.TokenManagement;

[SupportedOSPlatform("windows")]
public class TokenStorage : ITokenStorage
{
    public void SaveTokens(LoginResponse? loginResponse)
    {
        try
        {
            var jsonTokenData = JsonSerializer.Serialize(loginResponse);
            var encryptedData = ProtectedData.Protect(
                Encoding.UTF8.GetBytes(jsonTokenData),
                null,
                DataProtectionScope.CurrentUser);

            var filePath = GetTokenFilePath();
            Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException());
            File.WriteAllBytes(filePath, encryptedData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public LoginResponse? LoadTokens()
    {
        try
        {
            var filePath = GetTokenFilePath();
            if (!File.Exists(filePath)) return null;

            var encryptedData = File.ReadAllBytes(filePath);

            var jsonData = Encoding.UTF8.GetString(
                ProtectedData.Unprotect(
                    encryptedData,
                    null,
                    DataProtectionScope.CurrentUser));

            return JsonSerializer.Deserialize<LoginResponse>(jsonData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void DeleteTokens()
    {
        try
        {
            var filePath = GetTokenFilePath();
            if (File.Exists(filePath)) File.Delete(filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool ValidateTokens()
    {
        try
        {
            var tokens = LoadTokens();

            if (tokens == null)
            {
                Console.WriteLine(@"No tokens found in storage.");
                return false;
            }

            if (tokens.AccessTokenExpiryDate <= DateTime.UtcNow)
            {
                Console.WriteLine(@"Access token has expired.");
                return false;
            }

            if (tokens.RefreshTokenExpiryDate <= DateTime.UtcNow)
            {
                Console.WriteLine(@"Refresh token has expired.");
                return false;
            }

            Console.WriteLine(@"Tokens are valid.");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($@"Error validating tokens: {e.Message}");
            return false;
        }
    }

    private static string GetTokenFilePath()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        return Path.Combine(appData, "LearningApp", "tokens.bin");
    }
}