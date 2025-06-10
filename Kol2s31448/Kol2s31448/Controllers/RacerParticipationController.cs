using Kol2s31448.Exceptions;
using Kol2s31448.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2s31448.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacerParticipationController : ControllerBase
{
    private readonly IDbService _dbService;

    public RacerParticipationController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("racers/{id}/participations")]
    public async Task<IActionResult> GetRacerParticipationsById(int id)
    {
        try
        {
            var RacerParticipation = await _dbService.GetRacerParticipationsById(id);
            return Ok(RacerParticipation);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}