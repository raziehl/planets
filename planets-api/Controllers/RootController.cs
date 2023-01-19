using Microsoft.AspNetCore.Mvc;

namespace planets_api.Controllers;

[ApiController]
[Route("[controller]")]
public class RootController : ControllerBase
{
  private readonly ILogger<RootController> _logger;

  public RootController(ILogger<RootController> logger)
  {
    _logger = logger;
  }

  [HttpGet(Name = "GetWeatherForecast")]
  public String Get()
  {
    return "ASd";
  }
}
