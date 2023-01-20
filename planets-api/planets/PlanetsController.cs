using Microsoft.AspNetCore.Mvc;
namespace planets_api.Controllers;

[ApiController]
[Route("planets")]
public class PlanetsController : ControllerBase
{
  private readonly ILogger<RootController> _logger;

  public PlanetsController(ILogger<RootController> logger)
  {
    _logger = logger;
  }

  [HttpGet]
  public IActionResult HealthCheck()
  {
    return Ok(new { message = "Planets API Online" });
  }

}
