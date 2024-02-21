using System.Collections.Concurrent;
using System.Numerics;
using backend.api.Database;
using backend.api.Database.Entities;
using backend.api.Dtos;
using backend.api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.api.Services;

public class ItemService : IItemService
{
    private readonly DatabaseContext _context;

    public ItemService(DatabaseContext databaseContext)
    {
        _context = databaseContext;
    }

    public async Task<List<ItemEntity>> GetItems()
    {
        return await _context.ItemEntities.ToListAsync();
    }

    public async Task<ItemEntity> AddItem(ItemDto itemDto)
    {
        var item = new ItemEntity
        {
            ItemName = itemDto.ItemName,
            ItemDescription = itemDto.ItemDescription
        };

        await _context.ItemEntities.AddAsync(item);
        await _context.SaveChangesAsync();
        return item;
    }


    public async Task<ItemEntity?> ItemExists(string itemName)
    {
        var itemExists = await _context
            .ItemEntities
            .FirstOrDefaultAsync(rle => rle.ItemName == itemName);

        return itemExists;
    }

    public async Task<List<FactorialResultDto>> CalculateFactorials()
    {
        //for thread safety
        var factorialResults = new ConcurrentBag<FactorialResultDto>();
        var items = await GetItems();

       
        Parallel.ForEach(items, async item =>
        {
            var factorial = CalculateFactorial(item.Id);

            var factorialResult = new FactorialResultDto
            {
                ItemId = item.Id,
                Factorial = factorial.ToString()
            };

            factorialResults.Add(factorialResult);
        });

        return factorialResults.ToList(); // Convert ConcurrentBag to List before returning
    }

    private static BigInteger CalculateFactorial(long n)
    {
        BigInteger factorial = 1;
        for (long i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }

}