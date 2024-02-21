using backend.api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.api.Database.Seed
{
    public static class Seeder
    {
        public static void Seed(DatabaseContext context)
        {
            SeedItems(context);
        }

        private static void SeedItems(DatabaseContext databaseContext)
        {
            var item = new ItemEntity()
            {
                Id = 1,
                ItemId = Guid.NewGuid(),
                ItemName = "Convertible Car",
                ItemDescription =
                    "This convertible car is fast! The engine is powered by a neutrino based battery (not included). Power it up and let it go!"
            };

            // Check if the item exists in the database
            var existingItem = databaseContext.ItemEntities.FirstOrDefault(itm => itm.Id == item.Id);

            if (existingItem == null)
            {
                databaseContext.ItemEntities.Add(item);
            }
            else
            {
                existingItem.ItemId = item.ItemId;
                existingItem.ItemName = item.ItemName;
                existingItem.ItemDescription = item.ItemDescription;
            }

            databaseContext.SaveChanges();
        }
    }
}