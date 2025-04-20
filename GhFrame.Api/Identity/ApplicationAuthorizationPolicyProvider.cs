using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using GhFrame.Api.Models;

namespace GhFrame.Api.Identity;

public class ApplicationAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    : DefaultAuthorizationPolicyProvider(options)
{
    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = await base.GetPolicyAsync(policyName);

        if (policy is null)
        {
            if (Permissions.All().Contains(policyName))
            {
                policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .AddRequirements(new PermissionAuthorizationRequirement(policyName))
                    .RequireAuthenticatedUser()
                    .Build();
            }
        }

        return policy;
    }
}