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
    var crew = (await db.Crews.FindAsync(id));

    if(crew != null)
      await db.Entry<Crew>(crew).Collection(e => e.CrewMembers).LoadAsync();
    else throw new KeyNotFoundException("Crew not found");

    return crew;
  }

  public async Task Create(Crew crew) {
    Crew newCrew = new Crew{
      CrewName = crew.CrewName,
      ShuttleName = crew.ShuttleName
    };

    crew.CrewMembers.ForEach(async e => {
      var member = await db.CrewMembers.FindAsync(e.Id);
      if(member != null) {
        db.CrewMembers.Attach(member);
        newCrew.CrewMembers.Add(member);
      }
    });

    await db.Crews.AddAsync(newCrew);
    await db.SaveChangesAsync();


  }

  public async Task Update(int id, Crew newCrew) {
    var crew = await db.Crews.FindAsync(id);
    
    if(crew != null) {
      crew.CrewName = newCrew.CrewName;
      crew.ShuttleName = newCrew.ShuttleName;
      newCrew.CrewMembers.ForEach(async e => {
        var member = await db.CrewMembers.FindAsync(e.Id);
        if(member != null) {
          db.CrewMembers.Attach(member);
          crew.CrewMembers.Add(member);
        }
      });

      db.Crews.Update(crew);
      await db.SaveChangesAsync();
    }
  }

  public async Task Delete(int id) {
    db.Crews.Remove(await FindOne(id));
    await db.SaveChangesAsync();
  }
  
}