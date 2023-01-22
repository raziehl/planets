using common.models;
public interface ICrewsService
{
    IEnumerable<Crew> FindAll();
    Task<Crew> FindOne(int id);
    Task Create(Crew model);
    Task Update(Crew model);
    Task Delete(int id);
}

public class CrewsService: ICrewsService {
  private GeneralContext db;

  public CrewsService() {
    db = new GeneralContext();
  }

  public IEnumerable<Crew> FindAll() {
    return db.Crews;
  }

  public async Task<Crew> FindOne(int id) {
    var crew = await db.Crews.FindAsync(id);
    if (crew == null) throw new KeyNotFoundException("Planet not found");
    return crew;
  }

  public async Task Create(Crew crew) {
    // if(db.Planets.Any(e => e.Name == planet.Name))
    //   throw new ApplicationException();

    await db.Crews.AddAsync(crew);
    await db.SaveChangesAsync();
  }

  public async Task Update(Crew crew) {
    db.Crews.Update(crew);
    await db.SaveChangesAsync();
  }

  public async Task Delete(int id) {
    db.Crews.Remove(await FindOne(id));
    await db.SaveChangesAsync();
  }
  
}