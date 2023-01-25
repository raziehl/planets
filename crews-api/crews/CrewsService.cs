using common.models;
using Microsoft.EntityFrameworkCore;
// namespace crews_api.services;

public interface ICrewsService
{
    IEnumerable<Crew> FindAll();
    Task<Crew> FindOne(int id);
    Task Create(Crew model);
    Task Update(int id, Crew model);
    Task Delete(int id);
}

public class CrewsService: ICrewsService {
  private GeneralContext db;
  private ICrewMembersService _crewMembersService;

  public CrewsService(
    ICrewMembersService crewMembersService
  ) {
    db = new GeneralContext();
    _crewMembersService = crewMembersService;
  }

  public IEnumerable<Crew> FindAll() {
    return db.Crews.Include(e => e.CrewMembers);
  }

  public async Task<Crew> FindOne(int id) {
    var crew = await db.Crews.FindAsync(id);
    if (crew == null) throw new KeyNotFoundException("Crew not found");
    return crew;
  }

  public async Task Create(Crew crew) {
    // if(db.Planets.Any(e => e.Name == planet.Name))
    //   throw new ApplicationException();
    Crew newCrew = new Crew{
      CrewName = crew.CrewName
    };

    crew.CrewMembers.ForEach(async e => {
      db.CrewMembers.Attach(e);
      // newCrew.CrewMembers.Add((await _crewMembersService.FindOne(e.Id)));
      newCrew.CrewMembers.Add(e);
    });

    await db.Crews.AddAsync(newCrew);
    await db.SaveChangesAsync();


  }

  public async Task Update(int id, Crew newCrew) {
    Crew crew = await FindOne(id);

    crew.CrewName = newCrew.CrewName;
    crew.CrewMembers = newCrew.CrewMembers;

    db.Crews.Update(crew);
    await db.SaveChangesAsync();
  }

  public async Task Delete(int id) {
    db.Crews.Remove(await FindOne(id));
    await db.SaveChangesAsync();
  }
  
}