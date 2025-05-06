using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public required ApplicationUser User { get; set; }


}