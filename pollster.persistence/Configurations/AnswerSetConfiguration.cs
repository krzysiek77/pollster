using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pollster.domain.Entities;

namespace pollster.persistence.Configurations
{
    public class AnswerSetConfiguration : IEntityTypeConfiguration<AnswerSet>
    {
        public void Configure(EntityTypeBuilder<AnswerSet> builder)
        {
            builder.HasKey(e => e.AnswerSetId);

            builder.Property(e => e.AnswerSetId)
                .HasColumnName("AnswerSetId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.StartedAt)
                .IsRequired();
            
            builder.Property(e => e.FinishedAt)
                .IsRequired();

            builder.HasOne(e => e.Survey)
                .WithMany(f => f.AnswerSets)
                .HasForeignKey(e => e.SurveyId)
                .HasConstraintName("FK_Answer_Sets_Surveys")
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);;

            // builder.HasOne(e => e.Creator)
            //     .WithMany(f => f.AnswerSets)
            //     .HasForeignKey(e => e.CreatedById)
            //     .HasConstraintName("FK_Answer_Sets_Users");

            // audit
            builder.Property(e => e.IsExisting)
                .HasDefaultValue(true);

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
        }
    }
}