using GhFrame.Api.Models.Domain;

namespace GhFrame.Api.Abstractions.Repositories;

public interface IInventoryItemRepository
{
    Task<IEnumerable<InventoryItem>> GetAllAsync();
    Task<InventoryItem?> GetByIdAsync(string id);
    Task<InventoryItem> CreateAsync(InventoryItem item);
    Task<InventoryItem?> UpdateAsync(string id, InventoryItem updatedItem);
    Task<InventoryItem?> DeleteAsync(string id);
}