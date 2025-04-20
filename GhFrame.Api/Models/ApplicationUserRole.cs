using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public ApplicationUser User { get; }
    public ApplicationRole Role { get; }
}