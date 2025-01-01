using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Person : Auditable
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Length(3,30)]
    public string? FirstName { get; set; }
    [Length(3, 30)]
    public string? LastName { get; set; }
    public int? Age { get; set; }
}
