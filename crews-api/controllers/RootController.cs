using Microsoft.AspNetCore.Mvc;
using common.models;
namespace crews_api.Controllers;

[ApiController]
[Route("")]
public class RootController : ControllerBase
{
  private readonly ILogger<RootController> _logger;
  private GeneralContext db;

  public RootController(ILogger<RootController> logger)
  {
    _logger = logger;
    db = new GeneralContext();
  }

  [HttpGet]
  public CrewMember? GetCrewMember()
  {
    try {
      return db.CrewMembers.OrderBy(m => m.Id).FirstOrDefault();
    } catch(Exception e) {
      _logger.LogError(e.ToString());
      return null;
    }
  }

  [HttpPost]
  [Consumes("application/json")]
  public async Task<String> PostCrewMember(CrewMember member) {
    try {
      await db.CrewMembers.AddAsync(member);
      await db.SaveChangesAsync();
      return "Success";
    } catch(Exception e) {
      _logger.LogError(e.ToString());
      return "Unsuccessful";
    }
  }
}
