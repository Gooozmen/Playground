using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.ApplicationUser;

public class CreateApplicationUserCommand
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}