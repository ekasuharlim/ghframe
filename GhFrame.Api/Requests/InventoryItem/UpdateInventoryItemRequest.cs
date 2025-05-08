namespace GhFrame.Api.Requests.InventoryItem;

public class UpdateInventoryItemRequest
{
    public required string Name { get; set; }
    public required decimal Quantity { get; set; }
    public required string ItemGroupName { get; set; }
}
