using common.models;
using crews_api.utils;
// using crews_api.services;

public interface ICrewMembersService
{
    IEnumerable<CrewMember> FindAll();
    Task<CrewMember> FindOne(int id);
    CrewMember FindOneByEmail(String email);
    Task Create(CrewMember_CreationDto model);
    Task Update(int id, CrewMember_UpdateDto model);
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
    if (crew == null) throw new KeyNotFoundException("CrewMember not found");
    return crew;
  }

  public CrewMember FindOneByEmail(String email) {
    var member = db.CrewMembers.Where(e => e.Email == email).First();
    if (member == null) throw new KeyNotFoundException("CrewMember not found");
    return member;
  }

  public async Task Create(CrewMember_CreationDto createMemberDto) {
    if(db.CrewMembers.Any(e => e.Email == createMemberDto.Email))
      throw new Exception("CrewMember must have a unique Email");

    CrewMember member = new CrewMember(
      createMemberDto.Email,
      createMemberDto.Name,
      createMemberDto.Rank,
      createMemberDto.Species,
      createMemberDto.Role
    );
    member.PasswordHash = SecurityUtil.HashEncryptPassword(createMemberDto.Password);

    await db.CrewMembers.AddAsync(member);
    await db.SaveChangesAsync();
  }

  public async Task Update(int id, CrewMember_UpdateDto updateMemberDto) {
    CrewMember member = await FindOne(id);

    if (updateMemberDto.Email != member.Email && db.CrewMembers.Any(x => x.Email == updateMemberDto.Email))
      throw new Exception("CrewMember with the email '" + updateMemberDto.Email + "' already exists");

    if(!string.IsNullOrEmpty(updateMemberDto.Password))
      member.PasswordHash = SecurityUtil.HashEncryptPassword(updateMemberDto.Password);

    member.Email = !string.IsNullOrEmpty(updateMemberDto.Email) ? updateMemberDto.Email : member.Email;
    member.Name = !string.IsNullOrEmpty(updateMemberDto.Name) ? updateMemberDto.Name : member.Name;
    member.Rank = updateMemberDto.Rank != member.Rank ? updateMemberDto.Rank : member.Rank;
    member.Species = updateMemberDto.Species != member.Species ? updateMemberDto.Species : member.Species;
    member.Role = updateMemberDto.Role != member.Role ? updateMemberDto.Role : member.Role;

    db.CrewMembers.Update(member);
    await db.SaveChangesAsync();
  }

  public async Task Delete(int id) {
    db.CrewMembers.Remove(await FindOne(id));
    await db.SaveChangesAsync();
  }
}