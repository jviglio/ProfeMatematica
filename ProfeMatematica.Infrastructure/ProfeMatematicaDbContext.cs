using Microsoft.EntityFrameworkCore;
using ProfeMatematica.Domain.Entities;

namespace ProfeMatematica.Infrastructure;

public sealed class ProfeMatematicaDbContext : DbContext
{
    public ProfeMatematicaDbContext(DbContextOptions<ProfeMatematicaDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Exercise> Exercises => Set<Exercise>();

    public DbSet<Attempt> Attempts => Set<Attempt>();

    public DbSet<StudentProgress> StudentProgresses => Set<StudentProgress>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfeMatematicaDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
