using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhFrame.Api.Models.Configuration;

public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
    private const string _tableName = "ApplicationUserRoles";

    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.ToTable(_tableName);

        builder.HasOne(role => role.User)
            .WithMany(user => user.UserRoles)
            .HasForeignKey(role => role.UserId)
            .IsRequired();

        builder.HasOne(role => role.Role)
            .WithMany(role => role.UserRoles)
            .HasForeignKey(role => role.RoleId)
            .IsRequired();

    }

    
}