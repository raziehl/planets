using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;

[ApiController]
[Route("crews")]
public class CrewsController : ControllerBase
{
  private readonly ILogger<CrewsController> _logger;
  private readonly ICrewsService _crewsService;

  public CrewsController(
    ILogger<CrewsController> logger,
    ICrewsService crewsService
  ) {
    _logger = logger;
    _crewsService = crewsService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(_crewsService.FindAll());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) {
    return Ok(await _crewsService.FindOne(id));
  }

  [HttpPost]
  public async Task<IActionResult> Create(Crew crew) {
    await _crewsService.Create(crew);
    return Ok(new { message = "Planet Created" });
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(Crew crew) {
    await _crewsService.Update(crew);
    return Ok(new { message = "Planet Updated" });
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id) {
    await _crewsService.Delete(id);
    return Ok(new { message = String.Format("Planet {0} deleted", id) });
  }

}
