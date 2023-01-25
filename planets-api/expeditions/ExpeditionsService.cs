using common.models;
using Microsoft.EntityFrameworkCore;
public interface IExpeditionsService
{
    IEnumerable<Expedition> GetAll();
    Task<Expedition> GetExpedition(int id);
    Task Create(Expedition expedition);
    Task Update(int id, Expedition model);
    Task Delete(int id);
}

public class ExpeditionsService: IExpeditionsService {
  private GeneralContext db;

  public ExpeditionsService() {
    db = new GeneralContext();
  }

  public IEnumerable<Expedition> GetAll() {
    return db.Expeditions.Include(e => e.Planet).Include(e => e.Crew);
  }

  public async Task<Expedition> GetExpedition(int id) {
    var expedition = await db.Expeditions.FindAsync(id);
    if (expedition == null) throw new KeyNotFoundException("Expedition not found");
    return expedition;
  }

  public async Task Create(Expedition expedition) {
    
    var crew = await db.Crews.FindAsync(expedition.Crew.Id);
    var planet = await db.Planets.FindAsync(expedition.Planet.Id);

    if(crew != null && planet != null) {
      Expedition newExpedition = new Expedition{
        Crew = crew,
        CrewId = crew.Id,
        Planet = planet,
        PlanetId = planet.Id,
        Status = expedition.Status
      };

      await db.Expeditions.AddAsync(newExpedition);
      await db.SaveChangesAsync();
    } else {
      throw new Exception("Crew or Planet not found");
    }
  }

  public async Task Update(int id, Expedition newPlanet) {
    Expedition expedition = await GetExpedition(id);



    db.Expeditions.Update(expedition);
    await db.SaveChangesAsync();
  }

  public async Task Delete(int id) {
    db.Expeditions.Remove(await GetExpedition(id));
    await db.SaveChangesAsync();
  }
  
}