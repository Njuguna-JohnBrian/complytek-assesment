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
                itm.ItemId,
                itm.ItemName,
                itm.ItemDescription,
                itm.IsComplete,
                itm.CreatedDtm
            })
        );
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> AddItemsAsync()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}