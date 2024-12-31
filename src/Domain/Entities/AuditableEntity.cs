namespace Domain.Entities;

public abstract class AuditableEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Guid CreatedBy { get; set; } = Guid.NewGuid();
    public DateTime? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
}
