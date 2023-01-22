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
  [Consumes("application/json")]
  public async Task<IActionResult> Create(CrewMember_CreationDto createMemberDTO) {
    await _crewMembersService.Create(createMemberDTO);
    return Ok(new { message = "CrewMember Created" });
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, CrewMember_UpdateDto updateMemberDTO) {
    await _crewMembersService.Update(id, updateMemberDTO);
    return Ok(new { message = "CrewMember Updated" });
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id) {
    await _crewMembersService.Delete(id);
    return Ok(new { message = String.Format("CrewMember {0} deleted", id) });
  }

}
