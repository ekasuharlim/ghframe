using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser User { get; init;}
    public ApplicationRole Role { get; init;}

    public ApplicationUserRole(ApplicationUser user, ApplicationRole role) {
        User = user;
        Role = role;
    }

}