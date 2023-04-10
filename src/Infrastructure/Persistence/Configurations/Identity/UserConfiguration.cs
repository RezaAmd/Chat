using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Infrastructure.Persistence.Configurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id); // primary key
        builder.Property(u => u.Id).ValueGeneratedNever();

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(15)
            .IsRequired();
        builder.HasIndex(u => u.PhoneNumber)
            .IsUnique();

        builder.Property(u => u.RegionCode)
            .IsRequired()
            .HasColumnType("byte");

        builder.Property(u => u.Username)
            .HasMaxLength(50)
            ;


        // Value objects
        builder.OwnsOne(u => u.PasswordHash, option =>
        {
            option.Property(ph => ph.Value).HasMaxLength(30);
        });

        builder.OwnsOne(u => u.FullName, option =>
        {
            option.Property(fn => fn.Name).HasMaxLength(20);
            option.Property(fn => fn.Surname).HasMaxLength(20);
        });

        // Each User can have many entries in the UserRole join table
        builder.HasMany(u => u.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    }
}