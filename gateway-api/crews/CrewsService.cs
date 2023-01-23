using Microsoft.AspNetCore.Mvc;
namespace gateway_api.services;

public interface ICrewsService {
  Task<Object?> getAllMembers();
}

public class CrewsService: ICrewsService
{
  private readonly ILogger<CrewsService> _logger;
  private readonly HttpClient _http;

  public CrewsService(
    ILogger<CrewsService> logger,
    IHttpClientFactory httpClientFactory
  )
  {
    _logger = logger;
    _http = httpClientFactory.CreateClient();
    _http.BaseAddress = new Uri("http://localhost:3001");
    Console.WriteLine(_http.BaseAddress);
  }

  public async Task<Object?> getAllMembers() {
    var res = await _http.GetAsync("/crew_members");

    var content = await res.Content.ReadFromJsonAsync<Object>();

    Console.WriteLine(content?.ToString());

    // Console.WriteLine(res.ToString());

    return content;
  }

}
