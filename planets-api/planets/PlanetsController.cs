using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;

[ApiController]
[Route("planets")]
public class PlanetsController : ControllerBase
{
  private readonly ILogger<RootController> _logger;
  private readonly IPlanetsService _planetsService;

  public PlanetsController(
    ILogger<RootController> logger,
    IPlanetsService planetsService
  ) {
    _logger = logger;
    _planetsService = planetsService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(_planetsService.GetAll());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) {
    return Ok(await _planetsService.GetPlanet(id));
  }

  [HttpPost]
  public async Task<IActionResult> Create(Planet planet) {
    await _planetsService.Create(planet);
    return Ok(new { message = "Success" });
  }

}
