using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pollster.domain.Entities;

namespace pollster.persistence.Configurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasKey(e => e.SurveyId);

            builder.Property(e => e.SurveyId)
                .HasColumnName("SurveyId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.SurveyName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(e => e.User)
                .WithMany(f => f.Surveys)
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_Surveys_Users")
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