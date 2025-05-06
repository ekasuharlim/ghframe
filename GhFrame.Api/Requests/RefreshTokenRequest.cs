using System.Text.Json.Serialization;

namespace GhFrame.Api.Requests;

public sealed record RefreshTokenRequest
{
    public string AccessToken { get; init; }  = string.Empty;

    public string RefreshToken { get; init; } = string.Empty;
}