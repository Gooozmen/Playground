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

        builder.Property(p => p.FirstName)
            .HasColumnName("FirstName")
            .HasColumnOrder(2);
        
        builder.Property(p => p.MiddleName)
            .HasColumnName("MiddleName")
            .HasColumnOrder(3);

        builder.Property(p => p.LastName)
            .HasColumnName("LastName")
            .HasColumnOrder(4);
        
        builder.Property(p => p.BirthDate)
            .HasColumnName("BirthDate")
            .HasColumnOrder(5);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired()
            .HasColumnOrder(6);

        builder.Property(p => p.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnOrder(7)
            .HasMaxLength(100);

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnOrder(8);

        builder.Property(p => p.UpdatedBy)
            .HasColumnName("UpdatedBy")
            .HasColumnOrder(9)
            .HasMaxLength(100);

        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt")
            .HasColumnOrder(10);

        builder.Property(p => p.DeletedBy)
            .HasColumnName("DeletedBy")
            .HasColumnOrder(11)
            .HasMaxLength(100);

        builder.Property(p => p.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasColumnOrder(12)
            .IsRequired();
        
    }
    
}

