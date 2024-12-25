using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Person
{
    [Required]
    public Guid Id { get; set; }
    [DisplayName("Firt Name")]
    [Length(3,20)]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Age { get; set; }

    public Person() { }

    public Person(Guid id, string? firstName, string? lastName, int? age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}
