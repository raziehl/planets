using Microsoft.AspNetCore.Mvc;
using common.models;
namespace planets_api.Controllers;

[ApiController]
[Route("crew_members")]
public class CrewMembersController : ControllerBase
{
  private readonly ILogger<CrewMembersController> _logger;
  private readonly ICrewMembersService _crewMembersService;

  public CrewMembersController(
    ILogger<CrewMembersController> logger,
    ICrewMembersService crewMembersService
  ) {
    _logger = logger;
    _crewMembersService = crewMembersService;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    return Ok(_crewMembersService.FindAll());
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) {
    return Ok(await _crewMembersService.FindOne(id));
  }

  [HttpPost]
  public async Task<IActionResult> Create(CrewMember crewMember) {
    await _crewMembersService.Create(crewMember);
    return Ok(new { message = "Planet Created" });
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(CrewMember crewMember) {
    await _crewMembersService.Update(crewMember);
    return Ok(new { message = "Planet Updated" });
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id) {
    await _crewMembersService.Delete(id);
    return Ok(new { message = String.Format("Planet {0} deleted", id) });
  }

}
