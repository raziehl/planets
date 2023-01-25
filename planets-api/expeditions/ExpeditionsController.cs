using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;

[ApiController]
[Route("expeditions")]
public class ExpeditionsController : ControllerBase
{
  private readonly ILogger<PlanetsController> _logger;
  private readonly IExpeditionsService _expeditionsService;

  public ExpeditionsController(
    ILogger<PlanetsController> logger,
    IExpeditionsService expeditionsService
  ) {
    _logger = logger;
    _expeditionsService = expeditionsService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    try {
      return Ok(_expeditionsService.GetAll());
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) {
    try {
      return Ok(await _expeditionsService.GetExpedition(id));
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create(Expedition expedition) {
    try {
      await _expeditionsService.Create(expedition);
      return Ok(new { message = "Expedition Created" });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id) {
    try {
      await _expeditionsService.Delete(id);
      return Ok(new { message = String.Format("Expedition {0} deleted", id) });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

}
