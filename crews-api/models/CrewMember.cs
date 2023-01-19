namespace crews_api.models;

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

public class CrewMember {
  public int Id { get; set; }
  public String Name { get; set; }
  public Rank Rank { get; set;}


  public CrewMember(int id, String name, Rank rank) {
    Id = id;
    Name = name;
    Rank = rank;
  }


}