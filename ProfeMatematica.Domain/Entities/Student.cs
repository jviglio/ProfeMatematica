using ProfeMatematica.Domain.Common;

namespace ProfeMatematica.Domain.Entities;

public sealed class Student : Entity
{
    private readonly List<Attempt> _attempts = new();

    private Student(
        Guid id,
        string fullName,
        string email,
        string curso,
        DateTime createdAt) : base(id, createdAt)
    {
        FullName = fullName;
        Email = email;
        Curso = curso;
        Progress = StudentProgress.Create(id);
    }

    public string FullName { get; private set; }

    public string Email { get; private set; }

    public string Curso { get; private set; }

    public StudentProgress Progress { get; }

    public IReadOnlyCollection<Attempt> Attempts => _attempts.AsReadOnly();

    public static Student Create(string fullName, string email, string curso)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Student full name is required.", nameof(fullName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Student email is required.", nameof(email));

        if (string.IsNullOrWhiteSpace(curso))
            throw new ArgumentException("Student curso is required.", nameof(curso));

        return new Student(
            Guid.NewGuid(),
            fullName.Trim(),
            email.Trim(),
            curso.Trim(),
            DateTime.UtcNow);
    }

    public void Rename(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Student full name is required.", nameof(fullName));

        FullName = fullName.Trim();
    }

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Student email is required.", nameof(email));

        Email = email.Trim();
    }

    public void ChangeCurso(string curso)
    {
        if (string.IsNullOrWhiteSpace(curso))
            throw new ArgumentException("Student curso is required.", nameof(curso));

        Curso = curso.Trim();
    }

    public Attempt RegisterAttempt(Exercise exercise, bool isSuccessful, string? feedback = null)
    {
        ArgumentNullException.ThrowIfNull(exercise);

        var attempt = Attempt.Create(Id, exercise.Id, isSuccessful, feedback);

        _attempts.Add(attempt);

        if (isSuccessful)
            Progress.RegisterSuccess();
        else
            Progress.RegisterFailure();

        return attempt;
    }
}