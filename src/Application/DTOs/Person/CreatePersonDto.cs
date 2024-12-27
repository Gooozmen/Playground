using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Person;

public class CreatePersonDto
{ 
    [Required]
    public Guid Id { get; set; }
    [Length(3, 20)]
    public string? FirstName { get; set; }
    [Length(3, 20)]
    public string? LastName { get; set; }
    public int? Age { get; set; }

    public CreatePersonDto() { }

    public CreatePersonDto(Guid id, string? firstName, string? lastName, int? age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}

