using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;

[ApiController]
[Route("crews")]
public class CrewsController : ControllerBase
{
  private readonly ILogger<CrewsController> _logger;
  private readonly ICrewsService _crewsService;

  public CrewsController(
    ILogger<CrewsController> logger,
    ICrewsService crewsService
  ) {
    _logger = logger;
    _crewsService = crewsService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    try {
      return Ok(_crewsService.FindAll());
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) {
    try {
      return Ok(await _crewsService.FindOne(id));
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create(Crew crew) {
    try {
      await _crewsService.Create(crew);
      return Ok(new { message = "Crew Created" });
    } catch(Exception e) {
      _logger.LogWarning(e.ToString());
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, Crew crew) {
    try {
      await _crewsService.Update(id, crew);
      return Ok(new { message = "Crew Updated" });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id) {
    try {
      await _crewsService.Delete(id);
      return Ok(new { message = String.Format("Crew {0} deleted", id) });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

}
