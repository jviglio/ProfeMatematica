using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfeMatematica.Domain.Entities;

namespace ProfeMatematica.Infrastructure.Configurations;

public sealed class StudentProgressConfiguration : IEntityTypeConfiguration<StudentProgress>
{
    public void Configure(EntityTypeBuilder<StudentProgress> builder)
    {
        builder.ToTable("StudentProgresses");

        builder.HasKey(progress => progress.Id);

        builder.Property(progress => progress.Id)
            .ValueGeneratedNever();

        builder.Property(progress => progress.StudentId)
            .IsRequired();

        builder.Property(progress => progress.SuccessfulAttempts)
            .IsRequired();

        builder.Property(progress => progress.FailedAttempts)
            .IsRequired();

        builder.Property(progress => progress.CurrentStreak)
            .IsRequired();

        builder.Property(progress => progress.CreatedAt)
            .IsRequired();

        builder.HasIndex(progress => progress.StudentId)
            .IsUnique();
    }
}
