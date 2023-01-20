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
