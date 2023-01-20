namespace common.models;

public static class PlanetStatus {
  public static readonly string OK = "OK";
  public static readonly string BangOK = "!OK";
  public static readonly string TODO = "TODO";
  public static readonly string EnRoute = "En Route";
}

public class Planet {
  public int Id { get; set; }
  public String Name { get; set; }
  public String Description { get; set; }
  public String Status {
    get;
    private set;
  } = PlanetStatus.TODO;
  

  public Planet(
    int id,
    String name,
    String description,
    String status
  ) {
    Id = id;
    Name = name;
    Description = description;

    SetStatus(status);
  }


  public void SetStatus(String value) {
    if(value == PlanetStatus.OK || value == PlanetStatus.BangOK || value == PlanetStatus.TODO || value == PlanetStatus.EnRoute) {
      Status = value;
    } else {
      throw new ArgumentException("Wrong argument", "Wrong argument here");
    }
  }
}