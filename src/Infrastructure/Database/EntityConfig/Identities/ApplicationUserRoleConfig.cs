using Domain.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class ApplicationUserRoleConfig: IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        // Table name
        builder.ToTable("AspNetUserRoles");

        // Composite primary key
        builder.HasKey(x => new { x.UserId, x.RoleId });

        // Foreign key relationships
        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ApplicationRole>()
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        // Audit properties
        builder.Property<DateTime>("CreatedAt")
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property("CreatedBy")
            .HasColumnName("CreatedBy")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property<DateTime?>("UpdatedAt")
            .HasColumnName("UpdatedAt");

        builder.Property("UpdatedBy")
            .HasColumnName("UpdatedBy")
            .HasMaxLength(100);

        builder.Property<DateTime?>("DeletedAt")
            .HasColumnName("DeletedAt");

        builder.Property("DeletedBy")
            .HasColumnName("DeletedBy")
            .HasMaxLength(100);

        builder.Property("IsDeleted")
            .HasColumnName("IsDeleted")
            .IsRequired();
    }
}