using System.ComponentModel.DataAnnotations;

namespace GhFrame.Api.Requests.Warehouse;

public class CreateWarehouseRequest
{
    [Required]
    public string? Id {get; set;}
    [Required]
    public string? Name { get; set; }
}