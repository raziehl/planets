using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using crews_api.utils;
namespace crews_api.Controllers;

[ApiController]
[Route("")]
public class RootController : ControllerBase
{
  private readonly ILogger<RootController> _logger;
  private readonly ICrewMembersService _crewMembersService;
  private GeneralContext db;

  public RootController(
    ILogger<RootController> logger,
    ICrewMembersService crewMembersService
  ) {
    _logger = logger;
    _crewMembersService = crewMembersService;
    db = new GeneralContext();
  }

  [HttpPost("login")]
  [Consumes("application/json")]
  public IActionResult Login(LoginDto login)
  {
    try {
      var member = _crewMembersService.FindOneByEmail(login.Email);
      if(!string.IsNullOrEmpty(member.PasswordHash) ? SecurityUtil.VerifyPassword(login.Password, member.PasswordHash) : throw new Exception("No password was provided"))
        return Ok(new {
          user = member,
          token = SecurityUtil.GenerateJSONWebToken()
        });
      else throw new ArgumentException("Invalid password");
    } catch(Exception e) {
      Console.WriteLine(e.Message);
      return BadRequest(e.Message);
    }
  }


  [HttpGet]
  public IActionResult HealthCheck()
  {
    return Ok(new { message = "Crews API Online" });
  }

  [HttpGet("auth_check")]
  [Authorize]
  public IActionResult AuthorizationCheck() {
    return Ok(new { message = "Working Authorization Scheme"});
  }
}
