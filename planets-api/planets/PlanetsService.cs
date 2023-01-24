using common.models;
public interface IPlanetsService
{
    IEnumerable<Planet> GetAll();
    Task<Planet> GetPlanet(int id);
    Task Create(Planet model);
    Task Update(int id, Planet model);
    Task Delete(int id);
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
    var planet = await db.Planets.FindAsync(id);
    if (planet == null) throw new KeyNotFoundException("Planet not found");
    return planet;
  }

  public async Task Create(Planet planet) {
    // if(db.Planets.Any(e => e.Name == planet.Name))
    //   throw new ApplicationException();

    await db.Planets.AddAsync(planet);
    await db.SaveChangesAsync();
  }

  public async Task Update(int id, Planet newPlanet) {
    Planet planet = await GetPlanet(id);

    planet.Name = newPlanet.Name;
    planet.Image = newPlanet.Image;
    planet.Description = newPlanet.Description;
    planet.Status = newPlanet.Status;

    db.Planets.Update(newPlanet);
    await db.SaveChangesAsync();
  }

  public async Task Delete(int id) {
    db.Planets.Remove(await GetPlanet(id));
    await db.SaveChangesAsync();
  }
  
}