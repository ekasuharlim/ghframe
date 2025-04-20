using Microsoft.AspNetCore.Authentication.BearerToken;
using System.Security.Claims;
using GhFrame.Api.Models;
using GhFrame.Api.Models.Shared;

namespace GhFrame.Api.Abstractions;

public interface IJwtProvider
{
    Task<Result<AccessTokenResponse>> GenerateToken(ClaimsPrincipal principal);

    Task<Result> RevokeToken(ClaimsPrincipal principal);

    Task<Result<AccessTokenResponse>> RefreshToken(string accessToken, string refreshToken);
}