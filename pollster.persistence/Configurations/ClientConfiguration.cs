using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pollster.domain.Entities;

namespace pollster.persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.ClientId);

            builder.Property(e => e.ClientId)
                .HasColumnName("ClientId")
                .HasMaxLength(6)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ClientName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.IsActive)
                .HasDefaultValue(true);

            // audit
            builder.Property(e => e.IsExisting)
                .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}