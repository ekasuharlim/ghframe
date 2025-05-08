using Microsoft.AspNetCore.Identity;

namespace GhFrame.Api.Models;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public required ApplicationRole Role { get; set; }

}