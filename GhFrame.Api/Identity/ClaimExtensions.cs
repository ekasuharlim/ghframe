using System.Security.Claims;
using GhFrame.Api.Responses;

namespace GhFrame.Api.Identity;

public static class ClaimExtensions
{
    public static ClaimResponse ToClaimResponse(this Claim claim)
    {
        return new ClaimResponse(claim.Type, claim.Value);
    }
}