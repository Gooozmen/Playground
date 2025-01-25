using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs.ApplicationUser;

public class ApplicationUserCommand
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

}

public class ApplicationUserChangePasswordCommand
{
    public string Id { get; set; }
    public string CurrentPassword { get; set; } 
    public string NewPassword { get; set; }
}
