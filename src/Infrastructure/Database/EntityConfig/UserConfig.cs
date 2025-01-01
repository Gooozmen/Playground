using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("User");

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnOrder(1);

        builder.Property(p => p.RoleId)
            .HasColumnName("RoleId")
            .HasColumnOrder (2);

        builder.Property(p => p.FirstName)
            .HasColumnName("FirstName")
            .HasColumnOrder(3);

        builder.Property(p => p.LastName)
            .HasColumnName("LastName")
            .HasColumnOrder(4);

        builder.Property(p => p.Email)
            .HasColumnName("Email")
            .HasColumnOrder(5);

        builder.Property(p => p.Password)
            .HasColumnName("Password")
            .HasColumnOrder(6);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired()
            .HasColumnOrder(7);

        builder.Property(p => p.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnOrder(8)
            .HasMaxLength(100);

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnOrder(9);

        builder.Property(p => p.UpdatedBy)
            .HasColumnName("UpdatedBy")
            .HasColumnOrder(10)
            .HasMaxLength(100);

        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt")
            .HasColumnOrder(11);

        builder.Property(p => p.DeletedBy)
            .HasColumnName("DeletedBy")
            .HasColumnOrder(12)
            .HasMaxLength(100);

        builder.Property(p => p.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasColumnOrder(13)
            .IsRequired();

        builder.HasOne(p => p.Role)
               .WithMany(u => u.Users)
               .HasForeignKey(u => u.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
    }
    
}

