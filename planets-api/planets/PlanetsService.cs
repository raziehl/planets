using common.models;
public interface IPlanetsService
{
    IEnumerable<Planet> GetAll();
    Task<Planet> GetPlanet(int id);
    Task Create(Planet model);
    Task Update(int id, Planet model);
    void Delete(int id);
}

public class PlanetsService: IPlanetsService {
  private GeneralContext db;

  public PlanetsService() {
    db = new GeneralContext();
  }

  public IEnumerable<Planet> GetAll() {
    return db.Planets;
  }

  public async Task<Planet> GetPlanet(int id) {
    var user = await db.Planets.FindAsync(id);
    if (user == null) throw new KeyNotFoundException("User not found");
    return user;
  }

  public async Task Create(Planet planet) {
    // if(db.Planets.Any(e => e.Name == planet.Name))
    //   throw new ApplicationException();

    await db.Planets.AddAsync(planet);
    await db.SaveChangesAsync();
  }

  public async Task Update(int id, Planet planet) {
    // var user = GetPlanet(id);

    db.Planets.Update(planet);
    await db.SaveChangesAsync();
  }

  public async void Delete(int id) {
    db.Planets.Remove(await GetPlanet(id));
    await db.SaveChangesAsync();
  }
  
}