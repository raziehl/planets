namespace common.models;

public class Planet {
  public int Id { get; set; }
  public String Name { get; set; }


  public Planet(int id, String name, Rank rank) {
    Id = id;
    Name = name;
  }


}