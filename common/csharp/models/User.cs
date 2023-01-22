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
      int id,
      String email,
      string passwordHash
    ) {
      Id = id;
      Email = email;
      PasswordHash = passwordHash;
    }

    // private string passwordHash;
    // private void PasswordHash(String value) {
    //   return value;
    // }
}