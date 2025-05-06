using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public required ApplicationUser User { get; init;}
    public required ApplicationRole Role { get; init;}


}