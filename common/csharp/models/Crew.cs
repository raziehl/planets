namespace common.models;

public class Crew {
  public int Id { get; set; }
  public String? CrewName { get; set; }
  public String? ShuttleName { get; set; }
  public List<CrewMember> CrewMembers { get; set; } = new();
}