using Microsoft.AspNetCore.Mvc;
using gateway_api.services;

namespace gateway_api.Controllers;

[ApiController]
[Route("crews_gateway")]
public class CrewsController : ControllerBase
{
  private readonly ILogger<RootController> _logger;
  private readonly ICrewsService _crewsService;

  public CrewsController(
    ILogger<RootController> logger,
    ICrewsService crewsService
  ) {
    _logger = logger;
    _crewsService = crewsService;
  }

  // [HttpGet]
  // public async Task<Object?> getAll() {
  //   try {
  //     return await _crewsService.get("/crews");
  //   } catch(Exception e) {
  //     _logger.LogWarning(e.Message);
  //     return BadRequest(e.Message);
  //   }
  // }

  // [HttpGet("{id}")]
  // public async Task<Object?> GetById(int id) {
  //   try {
  //     return Ok(await _crewsService.get("/crews/" + id));
  //   } catch(Exception e) {
  //     _logger.LogWarning(e.Message);
  //     return BadRequest(e.Message);
  //   }
  // }

  // [HttpGet("asd")]
  public async Task<Object?> Get(Object any) {
    Console.WriteLine("Sandy");
    return Request.Body;
  }

  // [HttpPost("asd")]
  // [Consumes("application/json")]
  // public async Task<Object?> Post(Object any, [FromBody] Object any2) {
  //   Console.WriteLine(any);
  //   Console.WriteLine(any2);
  //   return null;
  // }


  // [HttpPost]
  // public async Task<IActionResult> Create(Crew crew) {
  //   try {
  //     await _crewsService.Create(crew);
  //     return Ok(new { message = "Crew Created" });
  //   } catch(Exception e) {
  //     _logger.LogWarning(e.Message);
  //     return BadRequest(e.Message);
  //   }
  // }

  // [HttpPut]
  // public async Task<IActionResult> Update(Crew crew) {
  //   try {
  //     await _crewsService.Update(crew);
  //     return Ok(new { message = "Crew Updated" });
  //   } catch(Exception e) {
  //     _logger.LogWarning(e.Message);
  //     return BadRequest(e.Message);
  //   }
  // }

  // [HttpDelete("{id}")]
  // public async Task<IActionResult> Delete(int id) {
  //   try {
  //     await _crewsService.Delete(id);
  //     return Ok(new { message = String.Format("Crew {0} deleted", id) });
  //   } catch(Exception e) {
  //     _logger.LogWarning(e.Message);
  //     return BadRequest(e.Message);
  //   }
  // }

}
