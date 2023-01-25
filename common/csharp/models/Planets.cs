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
  // Planet.Status is now deprecated as the status is now tracked as the newest Expedition.Status
  public String Status {
    get => _status;
    set => _status = ValidateStatus(value);
  }
  public List<Expedition>? Expeditions { get; set; }


  /*
    For demonstration purposes only the Image will be stored as a base64 encoded string 
    in the database, otherwise in a real production environment i would've prefered to
    have the images uploaded to some storage bucket and only have the URL of the image
    in the database
  */
  public string? Image { get; set; }

  public Planet(
    int id,
    String name,
    String description,
    String status,
    String image
  ) {
    Id = id;
    Name = name;
    Description = description;
    Image = image;
    Status = status;
  }

  private string _status = PlanetStatus.TODO;
  private String ValidateStatus(String value) {
    if(value == PlanetStatus.OK || value == PlanetStatus.BangOK || value == PlanetStatus.TODO || value == PlanetStatus.EnRoute) {
      return value;
    } else {
      return PlanetStatus.TODO;
    }
  }
}
