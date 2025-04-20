using Microsoft.AspNetCore.Authorization;

namespace GhFrame.Api.Identity;

public class PermissionAuthorizationRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}