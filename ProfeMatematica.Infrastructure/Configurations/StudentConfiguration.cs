using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfeMatematica.Domain.Entities;

namespace ProfeMatematica.Infrastructure.Configurations;

public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(student => student.Id);

        builder.Property(student => student.Id)
            .ValueGeneratedNever();

        builder.Property(student => student.FullName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(student => student.CreatedAt)
            .IsRequired();

        builder.HasMany(student => student.Attempts)
            .WithOne()
            .HasForeignKey(attempt => attempt.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
