using Microsoft.AspNetCore.Mvc;

namespace backend.api.Controllers;

[ApiController]
[Route("/items")]
[Produces("application/json")]
public class ItemController : ControllerBase
{
    public ItemController()
    {
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> GetItems()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
    
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IActionResult> AddItems()
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}