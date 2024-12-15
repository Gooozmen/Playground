namespace Domain.Entities;

public class Person
{
    private Guid Id { get; set; }
    private string? FirstName { get; set; }
    private string? LastName { get; set; }
    private int? Age { get; set; }

    public Person(Guid id, string? firstName, string? lastName, int? age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}
