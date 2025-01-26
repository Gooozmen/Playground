using Domain.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class ApplicationUserLoginConfig: IEntityTypeConfiguration<ApplicationUserLogin>
{
    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
    {
        // Table name
        builder.ToTable("AspNetUserLogins");

        // Primary key
        builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });

        // Properties
        builder.Property(x => x.LoginProvider)
            .HasColumnName("LoginProvider")
            .HasColumnOrder(1)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(x => x.ProviderKey)
            .HasColumnName("ProviderKey")
            .HasColumnOrder(2)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(x => x.ProviderDisplayName)
            .HasColumnName("ProviderDisplayName")
            .HasColumnOrder(3)
            .HasMaxLength(100);

        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnOrder(4)
            .IsRequired();

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
        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
    }
}