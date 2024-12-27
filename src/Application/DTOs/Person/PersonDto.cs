using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Person;

public class PersonDto
{
    [Required]
    public Guid Id { get; set; }
    [Length(3, 20)]
    public string FirstName { get; set; }
    [Length(3, 20)]
    public string LastName { get; set; }
    public int Age { get; set; }
}
