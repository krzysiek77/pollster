using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pollster.domain.Entities;

namespace pollster.persistence.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(e => e.AnswerId);

            builder.Property(e => e.AnswerId)
                .HasColumnName("AnswerId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.AnswerText)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne(e => e.AnswerSet)
                .WithMany(f => f.Answers)
                .HasForeignKey("AnswerSetId")
                .HasConstraintName("FK_Answers_Answer_Sets")
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.PossibleAnswer)
                .WithMany(f => f.Answers)
                .HasForeignKey("PossibleAnswerId")
                .HasConstraintName("FK_Answers_Possible_Answers")
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
