using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GhFrame.Api.Models;
using GhFrame.Api.Models.Domain;

namespace GhFrame.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>(options)
{
    public const string Schema = "Authentication";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(null);

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

    }

    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    public DbSet<InventoryItem> InventoryItems {get; set;} = null!;
    public DbSet<Warehouse> Warehouses {get; set;} = null!;
}