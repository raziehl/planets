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
    try {
      return Ok(_crewMembersService.FindAll());
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) {
    try {
      return Ok(await _crewMembersService.FindOne(id));
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  [Consumes("application/json")]
  public async Task<IActionResult> Create(CrewMember_CreationDto createMemberDTO) {
    try {
      await _crewMembersService.Create(createMemberDTO);
      return Ok(new { message = "CrewMember Created" });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, CrewMember_UpdateDto updateMemberDTO) {
    try {
      await _crewMembersService.Update(id, updateMemberDTO);
      return Ok(new { message = "CrewMember Updated" });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id) {
    try {
      await _crewMembersService.Delete(id);
      return Ok(new { message = String.Format("CrewMember {0} deleted", id) });
    } catch(Exception e) {
      _logger.LogWarning(e.Message);
      return BadRequest(e.Message);
    }
  }

}
