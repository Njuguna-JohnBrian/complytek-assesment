using backend.api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.api.Database.EntityConfigs;

public class ItemConfig : IEntityTypeConfiguration<ItemEntity>
{
    public void Configure(EntityTypeBuilder<ItemEntity> builder)
    {
        builder.ToTable("Items");
        builder.Property(it => it.RowVersion).IsRowVersion();
        builder.Property(it => it.ItemId).ValueGeneratedOnAdd();
    }
}