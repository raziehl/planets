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

  [HttpGet()]
  public String Get()
  {
    return "Works";
  }
}
