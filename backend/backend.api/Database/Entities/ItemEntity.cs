using System.ComponentModel.DataAnnotations;

namespace backend.api.Database.Entities;

public sealed class ItemEntity
{
    [Key] public long Id { get; init; }
    [Required] public Guid ItemId { get; init; }
    [Required] public string ItemName { get; init; }
    public string? ItemDescription { get; init; } = string.Empty;
    public bool IsComplete { get; init; }
   public DateTime? CreatedDtm { get; set; } = DateTime.Now;
    [Timestamp] public byte[] RowVersion { get; set; }
}