// Models/Mappers/InventoryItemMapper.cs
using GhFrame.Api.Models.Domain;
using GhFrame.Api.Models.Dtos;
using GhFrame.Api.Requests.InventoryItem;


namespace GhFrame.Api.Models.Mappers;

public static class InventoryItemMapper
{
    public static InventoryItemDto ToDto(this InventoryItem item)
    {
        return new InventoryItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Quantity = item.Quantity,
            ItemGroupName = item.ItemGroupName,
            WarehouseId = item.WarehouseId,
            WarehouseName = item.Warehouse?.Name ?? string.Empty
        };
    }

    public static InventoryItem ToDomain(this InventoryItemDto dto)
    {
        return new InventoryItem
        {
            Id = dto.Id,
            Name = dto.Name,
            Quantity = dto.Quantity,
            ItemGroupName = dto.ItemGroupName,
            WarehouseId = dto.WarehouseId,
            Warehouse = new Warehouse { Id = dto.WarehouseId, Name = dto.WarehouseName }
        };
    }

    public static InventoryItem ToDomain(this CreateInventoryItemRequest request)
    {
        return new InventoryItem
        {
            Id = request.Id,
            WarehouseId = request.WarehouseId,
            Name = request.Name,
            Quantity = request.Quantity,
            ItemGroupName = request.ItemGroupName,
        };
    }
}
