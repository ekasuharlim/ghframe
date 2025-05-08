using GhFrame.Api.Abstractions.Repositories;
using GhFrame.Api.Models.Domain;
using GhFrame.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GhFrame.Api.Repositories;


public class WarehouseRepository : IWarehouseRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WarehouseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Warehouse>> GetAllAsync()
    {
        return await _dbContext.Warehouses.ToListAsync();
    }

    public async Task<Warehouse?> GetByIdAsync(string id)
    {
        return await _dbContext.Warehouses.FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task<Warehouse> CreateAsync(Warehouse warehouse)
    {
        await _dbContext.Warehouses.AddAsync(warehouse);
        await _dbContext.SaveChangesAsync();
        return warehouse;
    }

    public async Task<Warehouse?> UpdateAsync(string id, Warehouse updatedWarehouse)
    {
        var existing = await _dbContext.Warehouses.FirstOrDefaultAsync(w => w.Id == id);
        if (existing == null)
            return null;

        existing.Name = updatedWarehouse.Name;
        await _dbContext.SaveChangesAsync();
        return existing;
    }

    public async Task<Warehouse?> DeleteAsync(string id)
    {
        var warehouse = await _dbContext.Warehouses.FirstOrDefaultAsync(w => w.Id == id);
        if (warehouse == null)
            return null;

        _dbContext.Warehouses.Remove(warehouse);
        await _dbContext.SaveChangesAsync();
        return warehouse;
    }
}