using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class UserRole : Auditable
{
    [Key]
    [Length(3, 50)]
    public string Id { get; set; }
    [Length(3,50)]
    public string Description { get; set; }
    [JsonIgnore]
    public ICollection<User> Users { get; set; }
}
