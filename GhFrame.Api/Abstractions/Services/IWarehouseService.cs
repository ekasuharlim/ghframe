using GhFrame.Api.Models.Domain;


namespace GhFrame.Api.Abstractions.Services;

public interface IWarehouseService
{
    Task<IEnumerable<Warehouse>> GetAllAsync();
    Task<Warehouse?> GetByIdAsync(string id);
    Task<Warehouse> CreateAsync(Warehouse warehouse);
    Task<Warehouse?> UpdateAsync(string id, Warehouse warehouse);
    Task<Warehouse?> DeleteAsync(string id);
}