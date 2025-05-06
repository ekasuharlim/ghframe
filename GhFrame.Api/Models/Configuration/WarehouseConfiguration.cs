
namespace GhFrame.Api.Models.Configuration;

using GhFrame.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WarehouseConfiguraton : IEntityTypeConfiguration<Warehouse>
{
    private const string _tableName = "Warehouses";

    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable(_tableName);
        builder.HasKey(w => new{w.Id});
    }
}