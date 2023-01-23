using Microsoft.AspNetCore.Mvc;
using gateway_api.services;

namespace gateway_api.Controllers;

[ApiController]
[Route("")]
public class RootController : ControllerBase
{
  private readonly ILogger<RootController> _logger;
  private readonly ICrewsService _crewsService;

  public RootController(
    ILogger<RootController> logger,
    ICrewsService crewsService
  ) {
    _logger = logger;
    _crewsService = crewsService;
  }

  [HttpGet]
  public async Task<Object?> getCrewMembers() {
    return await _crewsService.getAllMembers();
  }

  [HttpGet("healthcheck")]
  public IActionResult HealthCheck()
  {
    return Ok(new { message = "Gateway API working" });
  }
}
