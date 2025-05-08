using Microsoft.AspNetCore.Mvc;
using GhFrame.Api.Abstractions.Services;
using GhFrame.Api.Models.Dtos;
using GhFrame.Api.Models.Mappers;
using GhFrame.Api.Models.Domain;
using GhFrame.Api.Requests.Warehouse;

namespace GhFrame.Api.Endpoints.Controllers;

[ApiController]
[Route("api/[controller]")]
[Tags("Warehouses")]
public class WarehousesController : ControllerBase
{
    private readonly IWarehouseService _service;

    public WarehousesController(IWarehouseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAll()
    {
        var warehouses = await _service.GetAllAsync();
        return Ok(warehouses.Select(w => w.ToDto()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WarehouseDto>> GetById(string id)
    {
        var warehouse = await _service.GetByIdAsync(id);
        return warehouse is not null ? Ok(warehouse.ToDto()) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<WarehouseDto>> Create(CreateWarehouseRequest request)
    {
        var warehouse = new Warehouse { Id = request.Id!, Name = request.Name! };
        var created = await _service.CreateAsync(warehouse);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<WarehouseDto>> Update(string id, UpdateWarehouseRequest request)
    {
        var updatedWarehouse = new Warehouse { Id = id, Name = request.Name! };
        var result = await _service.UpdateAsync(id, updatedWarehouse);
        return result is not null ? Ok(result.ToDto()) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<WarehouseDto>> Delete(string id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted is not null ? Ok(deleted.ToDto()) : NotFound();
    }
}
