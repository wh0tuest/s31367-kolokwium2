using Microsoft.AspNetCore.Mvc;
using s31367_kolokwium2.Models.DTOs;
using s31367_kolokwium2.Services;

namespace s31367_kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController(IPlayersService playersService) : ControllerBase
{
    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayerMatches(int id)
    {
        var result = await playersService.GetPlayerWithMatchesAsync(id);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddPlayer([FromBody] CreatePlayerDto request)
    {
        var response = await playersService.AddPlayerWithMatchesAsync(request);
        return response.IsSuccess
            ? Created($"/api/players/{response.PlayerId}", null)
            : BadRequest(response.ErrorMessage);
    }
}