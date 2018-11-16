using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pollster.domain.Entities;

namespace pollster.persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(e => e.QuestionId);

            builder.Property(e => e.QuestionId)
                .HasColumnName("QuestionId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.QuestionText)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(e => e.QuestionResponseType)
                .IsRequired();

            builder.Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(e => e.Survey)
                .WithMany(f => f.Questions)
                .HasForeignKey("SurveyId")
                .HasConstraintName("FK_Questions_Surveys")
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);;

            // audit
            builder.Property(e => e.IsExisting)
                .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}