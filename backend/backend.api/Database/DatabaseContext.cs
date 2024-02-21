using backend.api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.api.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected DatabaseContext()
    {
    }

    public virtual DbSet<ItemEntity> ItemEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfiguration();
    }
}