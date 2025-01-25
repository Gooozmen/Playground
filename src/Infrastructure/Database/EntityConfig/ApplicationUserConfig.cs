using Domain.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfig;

public class ApplicationUserConfig: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
         // Table name and primary key
        builder.ToTable("AspNetUsers");
        builder.HasKey(x => x.Id);

        // Column configurations
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnOrder(1)
            .IsRequired();

        builder.Property(x => x.UserName)
            .HasColumnName("UserName")
            .HasColumnOrder(2)
            .HasMaxLength(256);

        builder.Property(x => x.NormalizedUserName)
            .HasColumnName("NormalizedUserName")
            .HasColumnOrder(3)
            .HasMaxLength(256);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasColumnOrder(4)
            .HasMaxLength(256);

        builder.Property(x => x.NormalizedEmail)
            .HasColumnName("NormalizedEmail")
            .HasColumnOrder(5)
            .HasMaxLength(256);

        builder.Property(x => x.EmailConfirmed)
            .HasColumnName("EmailConfirmed")
            .HasColumnOrder(6)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .HasColumnName("PasswordHash")
            .HasColumnOrder(7);

        builder.Property(x => x.SecurityStamp)
            .HasColumnName("SecurityStamp")
            .HasColumnOrder(8);

        builder.Property(x => x.ConcurrencyStamp)
            .HasColumnName("ConcurrencyStamp")
            .HasColumnOrder(9);

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasColumnOrder(10);

        builder.Property(x => x.PhoneNumberConfirmed)
            .HasColumnName("PhoneNumberConfirmed")
            .HasColumnOrder(11)
            .IsRequired();

        builder.Property(x => x.TwoFactorEnabled)
            .HasColumnName("TwoFactorEnabled")
            .HasColumnOrder(12)
            .IsRequired();

        builder.Property(x => x.LockoutEnd)
            .HasColumnName("LockoutEnd")
            .HasColumnOrder(13);

        builder.Property(x => x.LockoutEnabled)
            .HasColumnName("LockoutEnabled")
            .HasColumnOrder(14)
            .IsRequired();

        builder.Property(x => x.AccessFailedCount)
            .HasColumnName("AccessFailedCount")
            .HasColumnOrder(15)
            .IsRequired();

        // Audit properties
        builder.Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnOrder(16)
            .IsRequired();

        builder.Property(x => x.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnOrder(17)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnOrder(18);

        builder.Property(x => x.UpdatedBy)
            .HasColumnName("UpdatedBy")
            .HasColumnOrder(19);

        builder.Property(x => x.DeletedAt)
            .HasColumnName("DeletedAt")
            .HasColumnOrder(20);

        builder.Property(x => x.DeletedBy)
            .HasColumnName("DeletedBy")
            .HasColumnOrder(21);

        builder.Property(x => x.IsDeleted)
            .HasColumnName("IsDeleted")
            .HasColumnOrder(22)
            .IsRequired();
    
    }
}