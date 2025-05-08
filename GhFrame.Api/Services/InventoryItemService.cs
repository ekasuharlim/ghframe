using GhFrame.Api.Abstractions.Repositories;
using GhFrame.Api.Abstractions.Services;
using GhFrame.Api.Models.Domain;

namespace GhFrame.Api.Services;

public class InventoryItemService : IInventoryItemService
{
    private readonly IInventoryItemRepository _repository;

    public InventoryItemService(IInventoryItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<InventoryItem>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<InventoryItem?> GetByIdAsync(string id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<InventoryItem> CreateAsync(InventoryItem item)
    {
        return await _repository.CreateAsync(item);
    }

    public async Task<InventoryItem?> UpdateAsync(string id, string warehouseId, InventoryItem updatedItem)
    {
        return await _repository.UpdateAsync(id, warehouseId, updatedItem);
    }

    public async Task<InventoryItem?> DeleteAsync(string id, string warehouseId)
    {
        return await _repository.DeleteAsync(id, warehouseId);
    }
}
