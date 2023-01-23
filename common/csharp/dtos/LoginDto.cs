using System.ComponentModel.DataAnnotations;

public class LoginDto {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    public LoginDto(
      string email,
      string password
    ) {
      Email = email;
      Password = password;
    }
}