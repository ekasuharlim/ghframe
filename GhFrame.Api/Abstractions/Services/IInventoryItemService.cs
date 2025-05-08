using GhFrame.Api.Models.Domain;

namespace GhFrame.Api.Abstractions.Services;

public interface IInventoryItemService
{
    Task<IEnumerable<InventoryItem>> GetAllAsync();
    Task<InventoryItem?> GetByIdAsync(string id);
    Task<InventoryItem> CreateAsync(InventoryItem item);
    Task<InventoryItem?> UpdateAsync(string id, string warehouseId,InventoryItem updatedItem);
    Task<InventoryItem?> DeleteAsync(string id, string warehouseId);
}
