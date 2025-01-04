using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : Auditable
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Length(3, 50)]
    public string RoleId { get; set; }
    [Length(3, 30)]
    public string FirstName { get; set; } = "N/A";
    [Length(3, 30)]
    public string LastName { get; set; } = "N/A";
    [Length(3, 40)]
    public string Email { get; set; }
    [Length(3, 30)]
    public string Password { get; set; }
    public UserRole Role { get; set; }

}
