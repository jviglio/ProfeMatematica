namespace ProfeMatematica.Domain.Common;

public abstract class Entity
{
    protected Entity(Guid id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }

    public DateTime CreatedAt { get; }
}
