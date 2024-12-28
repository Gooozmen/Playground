using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs;

public class PersonResponse
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Length(3, 20)]
    public string FirstName { get; set; } = string.Empty;
    [Length(3, 20)]
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
}
