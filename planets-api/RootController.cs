using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;


    // Console.WriteLine(new Planet(
    //   1,
    //   "Holy Terra",
    //   "The origin point",
    //   PlanetStatus.OK
    // ).Image);

[ApiController]
[Route("")]
public class RootController : ControllerBase
{
  private readonly ILogger<RootController> _logger;

  public RootController(ILogger<RootController> logger)
  {
    _logger = logger;
  }

  [HttpGet()]
  public IActionResult HealthCheck()
  {
    return Ok(new { message = "Planets API Online" });
  }

}
