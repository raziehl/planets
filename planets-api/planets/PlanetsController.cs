using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;

[ApiController]
[Route("planets")]
public class PlanetsController : ControllerBase
{
  private readonly ILogger<PlanetsController> _logger;
  private readonly IPlanetsService _planetsService;

  public PlanetsController(
    ILogger<PlanetsController> logger,
    IPlanetsService planetsService
  ) {
    _logger = logger;
    _planetsService = planetsService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    try {
      return Ok(_planetsService.GetAll());
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) {
    try {
      return Ok(await _planetsService.GetPlanet(id));
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create(Planet planet) {
    try {
      await _planetsService.Create(planet);
      return Ok(new { message = "Planet Created" });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, Planet planet) {
    try {
      await _planetsService.Update(id, planet);
      return Ok(new { message = "Planet Updated" });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id) {
    try {
      await _planetsService.Delete(id);
      return Ok(new { message = String.Format("Planet {0} deleted", id) });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

}
