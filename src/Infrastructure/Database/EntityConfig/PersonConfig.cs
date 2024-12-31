using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Person");

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .HasColumnOrder(1);

        builder.Property(p => p.FirstName)
            .HasColumnName("FirstName")
            .HasColumnOrder(2);
        
        builder.Property(p => p.LastName)
            .HasColumnName("LastName")
            .HasColumnOrder(3);

        builder.Property(p => p.Age).HasColumnName("Age")
            .HasColumnOrder(4);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired()
            .HasColumnOrder(5);

        builder.Property(p => p.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnOrder(6)
            .HasMaxLength(100);

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnOrder(7);

        builder.Property(p => p.UpdatedBy)
            .HasColumnName("UpdatedBy")
            .HasColumnOrder(8)
            .HasMaxLength(100);

        builder.Property(p => p.DeletedAt)
            .HasColumnName("DeletedAt")
            .HasColumnOrder(9);

        builder.Property(p => p.DeletedBy)
            .HasColumnName("DeletedBy")
            .HasColumnOrder(10)
            .HasMaxLength(100);

        builder.Property(p => p.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasColumnOrder(11)
            .IsRequired();
    }
}
