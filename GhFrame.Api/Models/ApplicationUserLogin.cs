using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public ApplicationUser User { get; init; }

    public ApplicationUserLogin(ApplicationUser user) 
    {
        User = user;
    }    

}