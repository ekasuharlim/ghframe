using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserRole : IdentityUserRole<Guid>
{
    public required ApplicationUser User { get; set;}
    public required ApplicationRole Role { get; set;}


}