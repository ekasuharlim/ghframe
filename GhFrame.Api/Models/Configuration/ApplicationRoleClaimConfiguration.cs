using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhFrame.Api.Models.Configuration;

public class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
{
    private const string _tableName = "ApplicationRoleClaims";

    public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
    {
        builder.ToTable(_tableName);

        builder.HasOne(claim => claim.Role)
            .WithMany(role => role.RoleClaims)
            .HasForeignKey(claim => claim.RoleId)
            .IsRequired();         
    }
}