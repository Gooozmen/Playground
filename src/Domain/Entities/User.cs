using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User : Auditable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public DateOnly BirthDate { get; set; } 
}
