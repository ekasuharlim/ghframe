using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser User { get; }
}