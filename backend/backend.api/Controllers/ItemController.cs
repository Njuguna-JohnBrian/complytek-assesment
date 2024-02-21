using backend.api.Dtos;
using backend.api.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.api.Controllers;

[ApiController]
[Route("/items")]
[Produces("application/json")]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetItemsAsync()
    {
        var items = await _itemService.GetItems();
        if (items.Count == 0)
            return new EmptyResult();

        return Ok(
            items.Select(itm => new
            {
                itm.Id,
                itm.ItemId,
                itm.ItemName,
                itm.ItemDescription,
                itm.CreatedDtm
            })
        );
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> AddItemsAsync([FromBody] ItemDto itemDto)
    {
        var itemExists = await _itemService.ItemExists(itemDto.ItemName);
        if (itemExists != null)
            return Conflict($"An item with the name {itemDto.ItemName} already exists");

        var item = await _itemService.AddItem(itemDto);
        return Ok(new
        {
            item.Id,
            item.ItemId,
            item.ItemName,
            item.ItemDescription,
            item.CreatedDtm
        });
    }

    [HttpGet]
    [Route("factorial")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFactorialsAsync()
    {
        var factorials = await _itemService.CalculateFactorials();
        return Ok(factorials);
    }
}