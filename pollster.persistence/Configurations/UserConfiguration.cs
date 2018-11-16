using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pollster.domain.Entities;

namespace pollster.persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.UserId)
                .HasColumnName("UserId")
                .HasMaxLength(6)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(e => e.UserEmail)
                .IsUnique();

            builder.Property(e => e.UserEmail)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(e => e.Client)
                .WithMany(f => f.Users)
                .HasForeignKey(e => e.ClientId)
                .HasConstraintName("FK_Users_Clients")
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
            
            // audit
            builder.Property(e => e.IsExisting)
                .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}