using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GhFrame.Api.Models.Configuration;

public class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
{
    private const string _tableName = "ApplicationUserClaims";

    public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
    {
        builder.ToTable(_tableName);
    }
}