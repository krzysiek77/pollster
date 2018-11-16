using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pollster.domain.Entities;

namespace pollster.persistence.Configurations
{
    public class PossibleAnswerConfiguration : IEntityTypeConfiguration<PossibleAnswer>
    {
        public void Configure(EntityTypeBuilder<PossibleAnswer> builder)
        {
            builder.HasKey(e => e.PossibleAnswerId);

            builder.Property(e => e.PossibleAnswerId)
                .HasColumnName("PossibleAnswerId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.PossibleAnswerText)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(e => e.Question)
                .WithMany(f => f.PossibleAnswers)
                .HasForeignKey("QuestionId")
                .HasConstraintName("FK_Possible_Answers_Questions")
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