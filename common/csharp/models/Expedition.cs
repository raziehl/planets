namespace common.models;

public class Expedition {
  public int Id { get; set; }
  public int PlanetId { get; set; }
  public Planet Planet { get; set; }
  public int CrewId { get; set; }
  public Crew Crew { get; set; }
  public String Status {
    get => _status;
    set => _status = ValidateStatus(value);
  }
  // public DateTime ReportDate { get; set; }


  private string _status = PlanetStatus.TODO;
  private String ValidateStatus(String value) {
    if(value == PlanetStatus.OK || value == PlanetStatus.BangOK || value == PlanetStatus.TODO || value == PlanetStatus.EnRoute) {
      return value;
    } else {
      return PlanetStatus.TODO;
    }
  }
}