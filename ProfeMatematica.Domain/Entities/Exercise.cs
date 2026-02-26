using ProfeMatematica.Domain.Common;

namespace ProfeMatematica.Domain.Entities;

public sealed class Exercise : Entity
{
    private Exercise(Guid id, string title, string statement, DateTime createdAt) : base(id, createdAt)
    {
        Title = title;
        Statement = statement;
    }

    public string Title { get; private set; }

    public string Statement { get; private set; }

    public static Exercise Create(string title, string statement)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Exercise title is required.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(statement))
        {
            throw new ArgumentException("Exercise statement is required.", nameof(statement));
        }

        return new Exercise(Guid.NewGuid(), title.Trim(), statement.Trim(), DateTime.UtcNow);
    }

    public void UpdateContent(string title, string statement)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Exercise title is required.", nameof(title));
        }

        if (string.IsNullOrWhiteSpace(statement))
        {
            throw new ArgumentException("Exercise statement is required.", nameof(statement));
        }

        Title = title.Trim();
        Statement = statement.Trim();
    }
}
