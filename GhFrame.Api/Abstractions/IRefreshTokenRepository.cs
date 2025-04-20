using GhFrame.Api.Models;

namespace GhFrame.Api.Abstractions;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetRefreshTokenAsync(string token);

    Task<RefreshToken?> GetRefreshTokenByJtiAsync(string jti);

    Task CreateRefreshTokenAsync(RefreshToken refreshToken);

    void UpdateRefreshToken(RefreshToken refreshToken);
}