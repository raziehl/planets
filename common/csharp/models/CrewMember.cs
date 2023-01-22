namespace common.models;

public enum Rank {
  Cadet,
  Ensign,
  Lieutenant,
  Captain
}

public enum Species {
  Human,
  Robot
}

public enum Role {
  Comand,
  Engineering,
  Medical,
  Analysis
}

public class CrewMember: User {
  public String Name { get; set; }
  public Rank Rank { get; set; }
  public Species Species { get; set; }
  public Role Role { get; set; }


  public CrewMember(
    int id,
    String email,
    string passwordHash,
    String name,
    Rank rank,
    Species species,
    Role role
  ): base(id, email, passwordHash) {
    Id = id;
    Name = name;
    Rank = rank;
    Species = species;
    Role = role;
  }


}