using System.ComponentModel.DataAnnotations;

namespace backend.api.Dtos;

public class ItemDto
{
    [Required(ErrorMessage = "Item name is required")]
    public required string ItemName { get; set; }

    [Required(ErrorMessage = "Item description is required")]
    public required string ItemDescription { get; set; }
}