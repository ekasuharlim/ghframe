using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser User { get; init;}

    public ApplicationUserToken(ApplicationUser user) 
    {
        User = user;
    }    
}