
using System.ComponentModel.DataAnnotations;

namespace GhFrame.Api.Models.Domain;
public class Warehouse 
{
    public required string Id {get; set; }
    public required string Name {get; set; }
}