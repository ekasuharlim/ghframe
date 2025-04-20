using System.Text.Json.Serialization;

namespace GhFrame.Api.Requests;

public sealed record RefreshTokenRequest
{
    public string AccessToken { get; init; }

    public string RefreshToken { get; init; }
}