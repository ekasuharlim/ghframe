
using System.ComponentModel.DataAnnotations.Schema;

namespace GhFrame.Api.Models.Domain;
public class InventoryItem
{
    public required string Id { get; set; }
    public required string WarehouseId { get; set; }
      
    public required string Name { get; set; } 
    public required decimal Quantity { get; set; }
   
    public required string ItemGroupName {get; set;} 
    
    [ForeignKey("WarehouseId")] 
    public required Warehouse Warehouse { get; set; } 

}