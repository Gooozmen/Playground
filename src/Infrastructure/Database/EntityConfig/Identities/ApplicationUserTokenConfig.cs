using Domain.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class ApplicationUserTokenConfig: IEntityTypeConfiguration<ApplicationUserToken>
{
    public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
    {
        builder.ToTable("AspNetUserTokens");

        // Composite primary key
        builder.HasKey(x => new { x.UserId, x.LoginProvider, x.Name });

        // Properties
        builder.Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(x => x.LoginProvider)
            .HasColumnName("LoginProvider")
            .HasColumnOrder(2)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnOrder(3)
            .HasMaxLength(450)
            .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnName("Value")
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

        // Foreign key relationship
        builder.HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
    }
}