using backend.api.Database.Entities;

namespace backend.api.Interfaces;

public interface IItemService
{
    Task<List<ItemEntity>> GetItems();
}