using GhFrame.Api.Abstractions.Services;
using GhFrame.Api.Models.Dtos;
using GhFrame.Api.Models.Mappers;
using GhFrame.Api.Requests.InventoryItem;
using Microsoft.AspNetCore.Mvc;

namespace GhFrame.Api.Endpoints.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryItemsController : ControllerBase
{
    private readonly IInventoryItemService _service;

    public InventoryItemsController(IInventoryItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InventoryItemDto>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items.Select(i => i.ToDto()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryItemDto>> GetById(string id)
    {
        var item = await _service.GetByIdAsync(id);
        return item is not null ? Ok(item.ToDto()) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<InventoryItemDto>> Create([FromBody] CreateInventoryItemRequest request)
    {
        var item = request.ToDomain();
        var created = await _service.CreateAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<InventoryItemDto>> Update(string id, [FromBody] UpdateInventoryItemRequest request)
    {
        var updatedItem = request.ToDomain(id);
        var result = await _service.UpdateAsync(id, updatedItem);
        return result is not null ? Ok(result.ToDto()) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<InventoryItemDto>> Delete(string id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted is not null ? Ok(deleted.ToDto()) : NotFound();
    }
}
