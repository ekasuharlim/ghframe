using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public required ApplicationUser User { get; set;}

}