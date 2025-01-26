using Domain.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class ApplicationRoleConfig: IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("AspNetRoles");

        // Primary key
        builder.HasKey(x => x.Id);

        // Properties
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnOrder(2)
            .HasMaxLength(256);

        builder.Property(x => x.NormalizedName)
            .HasColumnName("NormalizedName")
            .HasColumnOrder(3)
            .HasMaxLength(256);

        builder.Property(x => x.ConcurrencyStamp)
            .HasColumnName("ConcurrencyStamp")
            .HasColumnOrder(4);

        // Audit properties
        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnOrder(5)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnOrder(7);

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("UpdatedBy")
            .HasColumnOrder(8);

        builder.Property(x => x.DeletedAt)
            .HasColumnName("DeletedAt")
            .HasColumnOrder(9);

        builder.Property(x => x.DeletedBy)
            .HasColumnName("DeletedBy")
            .HasColumnOrder(10);

        builder.Property(x => x.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasColumnOrder(11)
            .IsRequired();
    }
}