using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class UserRole : Auditable
{
    [Key]
    [Length(3, 50)]
    public string Id { get; set; }
    [Length(3,50)]
    public string Description { get; set; }

    public ICollection<User> Users { get; set; } = new HashSet<User>();
}
