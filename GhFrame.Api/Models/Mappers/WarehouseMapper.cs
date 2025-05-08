using GhFrame.Api.Models.Domain;
using GhFrame.Api.Models.Dtos;

namespace GhFrame.Api.Models.Mappers;


public static class WarehouseMapper
{
    public static WarehouseDto ToDto(this Warehouse warehouse)
    {
        return new WarehouseDto
        {
            Id = warehouse.Id,
            Name = warehouse.Name
        };
    }
}