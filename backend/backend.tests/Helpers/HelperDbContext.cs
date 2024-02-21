using backend.api.Database;
using backend.api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.tests.Helpers;

public abstract class HelperDbContext
{
    public static DatabaseContext CreateDbContext(List<ItemEntity> items)
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var dbContext = new DatabaseContext(options);
        dbContext.ItemEntities.AddRange(items);
        dbContext.SaveChanges();
        return dbContext;
    }
}