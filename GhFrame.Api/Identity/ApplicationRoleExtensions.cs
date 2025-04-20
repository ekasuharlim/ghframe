using GhFrame.Api.Models;
using GhFrame.Api.Responses;

namespace GhFrame.Api.Identity;

public static class ApplicationRoleExtensions
{
    public static ApplicationRoleResponse ToApplicationRoleResponse(this ApplicationRole role)
    {
        return new ApplicationRoleResponse(role.Id.ToString(), role.Name);
    }
}