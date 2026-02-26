using ProfeMatematica.Domain.Common;

namespace ProfeMatematica.Domain.Entities;

public sealed class Student : Entity
{
    private readonly List<Attempt> _attempts = [];

    private Student(Guid id, string fullName, DateTime createdAt) : base(id, createdAt)
    {
        FullName = fullName;
        Progress = StudentProgress.Create(id);
    }

    public string FullName { get; private set; }

    public StudentProgress Progress { get; }

    public IReadOnlyCollection<Attempt> Attempts => _attempts.AsReadOnly();

    public static Student Create(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Student full name is required.", nameof(fullName));
        }

        return new Student(Guid.NewGuid(), fullName.Trim(), DateTime.UtcNow);
    }

    public void Rename(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Student full name is required.", nameof(fullName));
        }

        FullName = fullName.Trim();
    }

    public Attempt RegisterAttempt(Exercise exercise, bool isSuccessful, string? feedback = null)
    {
        ArgumentNullException.ThrowIfNull(exercise);

        var attempt = Attempt.Create(Id, exercise.Id, isSuccessful, feedback);

        _attempts.Add(attempt);

        if (isSuccessful)
        {
            Progress.RegisterSuccess();
        }
        else
        {
            Progress.RegisterFailure();
        }

        return attempt;
    }
}
