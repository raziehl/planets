using System.Text.Json.Serialization;

public class User {
    public int Id { get; set; }
    public String Email { get; set; }

    // Ignore PasswordHash when serializing User object as JSON
    [JsonIgnore]
    public String PasswordHash {
      get;
      set;
    }

    public User(
      String email
    ) {
      Email = email;
    }

    public void SetHashedPassword(String value) {
      PasswordHash = value + "23454";
    }
}