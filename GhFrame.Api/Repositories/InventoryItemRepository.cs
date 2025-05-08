using GhFrame.Api.Abstractions.Repositories;
using GhFrame.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;
using GhFrame.Api.Data;

namespace GhFrame.Api.Repositories;

public class InventoryItemRepository : IInventoryItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public InventoryItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<InventoryItem>> GetAllAsync()
    {
        return await _dbContext.InventoryItems
            .Include(i => i.Warehouse)
            .ToListAsync();
    }

    public async Task<InventoryItem?> GetByIdAsync(string id)
    {
        return await _dbContext.InventoryItems
            .Include(i => i.Warehouse)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<InventoryItem> CreateAsync(InventoryItem item)
    {
        _dbContext.InventoryItems.Add(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<InventoryItem?> UpdateAsync(string id, string warehouseId, InventoryItem updatedItem)
    {
        var existing = await _dbContext.InventoryItems.FindAsync(id, warehouseId);
        if (existing == null) return null;

        existing.Name = updatedItem.Name;
        existing.Quantity = updatedItem.Quantity;
        existing.ItemGroupName = updatedItem.ItemGroupName;

        await _dbContext.SaveChangesAsync();
        return existing;
    }

    public async Task<InventoryItem?> DeleteAsync(string id, string warehouseId)
    {
        var existing = await _dbContext.InventoryItems.FindAsync(id, warehouseId);
        if (existing == null) return null;

        _dbContext.InventoryItems.Remove(existing);
        await _dbContext.SaveChangesAsync();
        return existing;
    }
}
