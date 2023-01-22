using common.models;
public interface ICrewMembersService
{
    IEnumerable<CrewMember> FindAll();
    Task<CrewMember> FindOne(int id);
    Task Create(CrewMember model);
    Task Update(CrewMember model);
    Task Delete(int id);
}

public class CrewMembersService: ICrewMembersService {
  private GeneralContext db;

  public CrewMembersService() {
    db = new GeneralContext();
  }

  public IEnumerable<CrewMember> FindAll() {
    return db.CrewMembers;
  }

  public async Task<CrewMember> FindOne(int id) {
    var crew = await db.CrewMembers.FindAsync(id);
    if (crew == null) throw new KeyNotFoundException("Planet not found");
    return crew;
  }

  public async Task Create(CrewMember crew) {
    // if(db.Planets.Any(e => e.Name == planet.Name))
    //   throw new ApplicationException();

    await db.CrewMembers.AddAsync(crew);
    await db.SaveChangesAsync();
  }

  public async Task Update(CrewMember crew) {
    db.CrewMembers.Update(crew);
    await db.SaveChangesAsync();
  }

  public async Task Delete(int id) {
    db.CrewMembers.Remove(await FindOne(id));
    await db.SaveChangesAsync();
  }
  
}