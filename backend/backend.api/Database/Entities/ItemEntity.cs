using System.ComponentModel.DataAnnotations;

namespace backend.api.Database.Entities;

public sealed class ItemEntity
{
    [Key] public long Id { get; set; }
    [Required] public Guid ItemId { get; set; }
    [Required] public string ItemName { get; set; }
    public string? ItemDescription { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
   public DateTime? CreatedDtm { get; set; } = DateTime.Now;
}