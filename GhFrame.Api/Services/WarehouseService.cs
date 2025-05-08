using GhFrame.Api.Abstractions.Services;
using GhFrame.Api.Abstractions.Repositories;
using GhFrame.Api.Models.Domain;

namespace GhFrame.Api.Services;

public class WarehouseService : IWarehouseService
{
    private readonly IWarehouseRepository _repository;

    public WarehouseService(IWarehouseRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Warehouse>> GetAllAsync() => _repository.GetAllAsync();
    public Task<Warehouse?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);
    public Task<Warehouse> CreateAsync(Warehouse warehouse) => _repository.CreateAsync(warehouse);
    public Task<Warehouse?> UpdateAsync(string id, Warehouse warehouse) => _repository.UpdateAsync(id, warehouse);
    public Task<Warehouse?> DeleteAsync(string id) => _repository.DeleteAsync(id);
}