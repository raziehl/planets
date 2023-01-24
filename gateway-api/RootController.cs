using Microsoft.AspNetCore.Mvc;
namespace gateway_api.Controllers;

[ApiController]
[Route("")]
public class RootController : ControllerBase
{
  private readonly ILogger<RootController> _logger;

  public RootController(
    ILogger<RootController> logger
  ) {
    _logger = logger;
  }

  [HttpGet("healthcheck")]
  public IActionResult HealthCheck()
  {
    return Ok(new { message = "Gateway API working" });
  }
}
