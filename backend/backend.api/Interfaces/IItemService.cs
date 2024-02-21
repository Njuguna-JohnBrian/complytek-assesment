using System.Numerics;
using backend.api.Database.Entities;
using backend.api.Dtos;

namespace backend.api.Interfaces;

public interface IItemService
{
    Task<List<ItemEntity>> GetItems();

    Task<ItemEntity> AddItem(ItemDto roleDto);

    Task<ItemEntity?> ItemExists(string itemName);
    Task<List<FactorialResultDto>> CalculateFactorials();
}