using Domain.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class ApplicationRoleClaimConfig: IEntityTypeConfiguration<ApplicationRoleClaim>
{
     public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
    {
        // Table name
        builder.ToTable("AspNetRoleClaims");

        // Primary key
        builder.HasKey(x => x.Id);

        // Properties
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(x => x.RoleId)
            .HasColumnName("RoleId")
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(x => x.ClaimType)
            .HasColumnName("ClaimType")
            .HasColumnOrder(3)
            .HasMaxLength(100); // Assuming a max length for ClaimType

        builder.Property(x => x.ClaimValue)
            .HasColumnName("ClaimValue")
            .HasColumnOrder(4)
            .HasMaxLength(100); // Assuming a max length for ClaimValue

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

        // Foreign key relationship
        builder.HasOne<ApplicationRole>()
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
    }

}