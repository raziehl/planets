namespace common.models;

public class Crew {
  public int Id { get; set; }
  public String? CrewName { get; set; }
  public List<CrewMember> CrewMembers { get; set; } = new();


  // public Crew(int id, String name, List<CrewMember> crew) {
  //   Id = id;
  //   CrewName = name;
  //   CrewMembers = crew;
  // }

}