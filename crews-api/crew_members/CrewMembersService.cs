using common.models;
using System.Text.Json;
public interface ICrewMembersService
{
    IEnumerable<CrewMember> FindAll();
    Task<CrewMember> FindOne(int id);
    Task Create(CrewMember_CreationDto model);
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
    Console.WriteLine(crew.PasswordHash);
    return crew;
  }

  public async Task Create(CrewMember_CreationDto createMemberDto) {
    // if(db.Planets.Any(e => e.Name == planet.Name))
    //   throw new ApplicationException();

    CrewMember member = new CrewMember(
      createMemberDto.Email,
      createMemberDto.Name,
      createMemberDto.Rank,
      createMemberDto.Species,
      createMemberDto.Role
    );
    member.SetHashedPassword(createMemberDto.Password);

    await db.CrewMembers.AddAsync(member);
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