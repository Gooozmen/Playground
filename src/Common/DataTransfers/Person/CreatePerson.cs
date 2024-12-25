using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Common.DataTransfers.Person;

public class CreatePerson
{ 
    [Required]
    public Guid Id { get; set; }
    [Length(3, 20)]
    public string? FirstName { get; set; }
    [Length(3, 20)]
    public string? LastName { get; set; }
    public int? Age { get; set; }

    public CreatePerson() { }

    public CreatePerson(Guid id, string? firstName, string? lastName, int? age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}

