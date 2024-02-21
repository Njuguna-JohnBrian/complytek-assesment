using backend.api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.api.Database.Seed;

public static class Seeder
{
    public static void Seed(DatabaseContext context)
    {
        SeedItems(context);
    }

    private static void SeedItems(DbContext databaseContext)
    {
        var items = new List<ItemEntity>()
        {
            new()
            {
                Id = 1,
                ItemId = Guid.NewGuid(),
                ItemName = "Convertible Car",
                ItemDescription =
                    "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
                    "Power it up and let it go!",
            }
        };

        databaseContext.AddRange(items);
        databaseContext.SaveChanges();
    }
}