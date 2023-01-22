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
}