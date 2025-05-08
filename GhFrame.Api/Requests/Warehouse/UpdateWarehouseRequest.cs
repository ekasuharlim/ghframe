using System.ComponentModel.DataAnnotations;

namespace GhFrame.Api.Requests.Warehouse;

public class UpdateWarehouseRequest
{
    [Required]
    public string? Name { get; set; }
}