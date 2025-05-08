
namespace GhFrame.Api.Models.Configuration;

using GhFrame.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    private const string _tableName = "InventoryItems";

    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.ToTable(_tableName);
        builder.HasKey(ii => new { ii.Id, ii.WarehouseId});

        builder.HasOne(ii => ii.Warehouse)
            .WithMany(w => w.InventoryItems)
            .HasForeignKey(ii => ii.WarehouseId);
    }
}