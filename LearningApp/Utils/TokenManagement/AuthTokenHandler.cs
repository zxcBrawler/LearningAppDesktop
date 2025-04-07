using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using LearningApp.Models.Dto.Request;
using LearningApp.Models.Dto.Response;
using LearningApp.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace LearningApp.Utils.TokenManagement;

public class AuthTokenHandler(
    ITokenStorage tokenStorage,
    Lazy<ITokenRefreshService> tokenRefreshService)
    : DelegatingHandler
{
    private readonly HashSet<string> _noAuthEndpoints =
    [
        "/api/Authorization/Login",
        "/api/Authorization/Register",
        "/api/Authorization/RefreshToken"
    ];

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // skips authentication for several endpoints
        if (_noAuthEndpoints.Any(x => request.RequestUri?.AbsolutePath.Contains(x) == true))
            return await base.SendAsync(request, cancellationToken);

        var tokenData = tokenStorage.LoadTokens();

        if (tokenData != null && !string.IsNullOrEmpty(tokenData.AccessToken))
        {
            if (tokenData.IsAccessTokenValid)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenData.AccessToken);
            }
            else if (tokenData.IsRefreshTokenValid)
            {
                var refreshTokenRequest = new RefreshTokenRequestDto
                {
                    RefreshToken = tokenData.RefreshToken,
                    OldAccessToken = tokenData.AccessToken
                };
                var refreshedTokenData = await tokenRefreshService.Value.RefreshTokenAsync(refreshTokenRequest);

                if (refreshedTokenData.IsSuccess)
                {
                    tokenStorage.SaveTokens(new LoginResponse
                    {
                        AccessToken = refreshedTokenData.Value.Token,
                        AccessTokenExpiryDate = refreshedTokenData.Value.ExpiryDate,
                        RefreshToken = tokenData.RefreshToken,
                        RefreshTokenExpiryDate = tokenData.RefreshTokenExpiryDate
                    });
                    request.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", refreshedTokenData.Value.Token);
                }
            }
            else
            {
                tokenStorage.DeleteTokens();
            }
        }

        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        if (response.IsSuccessStatusCode) return response;
        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        Console.WriteLine($@"API Error: {response.StatusCode} - {content}");
        return response;
    }
}