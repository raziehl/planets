using System.ComponentModel.DataAnnotations;

public class CrewMember_CreationDto {
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}