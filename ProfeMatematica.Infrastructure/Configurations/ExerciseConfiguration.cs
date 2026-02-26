using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProfeMatematica.Domain.Entities;

namespace ProfeMatematica.Infrastructure.Configurations;

public sealed class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("Exercises");

        builder.HasKey(exercise => exercise.Id);

        builder.Property(exercise => exercise.Id)
            .ValueGeneratedNever();

        builder.Property(exercise => exercise.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(exercise => exercise.Statement)
            .IsRequired();

        builder.Property(exercise => exercise.CreatedAt)
            .IsRequired();

        builder.Property<string>("Tema")
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex("Tema");
    }
}
