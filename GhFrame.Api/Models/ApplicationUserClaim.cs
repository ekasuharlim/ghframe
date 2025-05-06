using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser User { get; init;}

    public ApplicationUserClaim(ApplicationUser user) 
    {
        User = user;
    }
}