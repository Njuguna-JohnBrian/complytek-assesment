using backend.api.Database;
using backend.api.Database.Entities;
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
}