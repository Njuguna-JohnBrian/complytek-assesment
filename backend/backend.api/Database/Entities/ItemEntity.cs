using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.api.Database.Entities;

public sealed class ItemEntity
{
    [Key] public long Id { get; set; }
    public Guid? ItemId { get; set; } = Guid.NewGuid();
    [Required] public string ItemName { get; set; }
    [Required] public string ItemDescription { get; set; }
    public DateTime? CreatedDtm { get; set; } = DateTime.Now;
}