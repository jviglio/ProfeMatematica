using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfeMatematica.Domain.Entities;

namespace ProfeMatematica.Infrastructure.Configurations;

public sealed class AttemptConfiguration : IEntityTypeConfiguration<Attempt>
{
    public void Configure(EntityTypeBuilder<Attempt> builder)
    {
        builder.ToTable("Attempts");

        builder.HasKey(attempt => attempt.Id);

        builder.Property(attempt => attempt.Id)
            .ValueGeneratedNever();

        builder.Property(attempt => attempt.StudentId)
            .IsRequired();

        builder.Property(attempt => attempt.ExerciseId)
            .IsRequired();

        builder.Property(attempt => attempt.IsSuccessful)
            .IsRequired();

        builder.Property(attempt => attempt.Feedback)
            .HasMaxLength(500);

        builder.Property(attempt => attempt.CreatedAt)
            .IsRequired();

        builder.HasIndex(attempt => attempt.StudentId);
    }
}
