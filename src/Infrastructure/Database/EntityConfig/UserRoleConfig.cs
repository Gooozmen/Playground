using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("UserRole");

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnOrder(1);

        builder.Property(p => p.Description)
            .HasColumnName("Description")
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired()
            .HasColumnOrder(3);

        builder.Property(p => p.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnOrder(4)
            .HasMaxLength(100);

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnOrder(5);

        builder.Property(p => p.UpdatedBy)
            .HasColumnName("UpdatedBy")
            .HasColumnOrder(6)
            .HasMaxLength(100);

        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt")
            .HasColumnOrder(7);

        builder.Property(p => p.DeletedBy)
            .HasColumnName("DeletedBy")
            .HasColumnOrder(8)
            .HasMaxLength(100);

        builder.Property(p => p.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasColumnOrder(9)
            .IsRequired();

        builder.HasMany(r => r.Users)
              .WithOne(u => u.Role)
              .HasForeignKey(u => u.RoleId)
              .OnDelete(DeleteBehavior.Restrict);
    }
}
