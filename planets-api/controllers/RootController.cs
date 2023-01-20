using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;

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
  public String Get()
  {
    Console.WriteLine(new Planet(
      1,
      "Holy Terra",
      "The origin point",
      PlanetStatus.OK
    ).Status);
    return "Works";
  }

}
