namespace GhFrame.Api.Models.Dtos;

public class InventoryItemDto
{
    public required string Id { get; set; }
    public required string WarehouseId { get; set; }
    public required string Name { get; set; }
    public required decimal Quantity { get; set; }
    public required string ItemGroupName { get; set; }
    public required string WarehouseName { get; set; } // Optional projection
}
