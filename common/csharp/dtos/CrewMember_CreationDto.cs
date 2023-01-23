using System.ComponentModel.DataAnnotations;
using common.models;

public class CrewMember_CreationDto {
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public Rank Rank { get; set; }
    public Species Species { get; set; }
    public Role Role { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    public CrewMember_CreationDto(
      string name,
      string email,
      Rank rank,
      Species species,
      Role role,
      string password
    ) {
      Name = name;
      Email = email;
      Rank = rank;
      Species = species;
      Role = role;
      Password = password;
    }
}