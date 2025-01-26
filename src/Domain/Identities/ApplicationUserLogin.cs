using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identities;

public class ApplicationUserLogin : IdentityUserLogin<Guid>, IAuditable
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
}