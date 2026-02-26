using ProfeMatematica.Domain.Common;

namespace ProfeMatematica.Domain.Entities;

public sealed class Attempt : Entity
{
    private Attempt(
        Guid id,
        Guid studentId,
        Guid exerciseId,
        bool isSuccessful,
        DateTime createdAt,
        string? feedback) : base(id, createdAt)
    {
        StudentId = studentId;
        ExerciseId = exerciseId;
        IsSuccessful = isSuccessful;
        Feedback = feedback;
    }

    public Guid StudentId { get; }

    public Guid ExerciseId { get; }

    public bool IsSuccessful { get; }

    public string? Feedback { get; }

    public static Attempt Create(Guid studentId, Guid exerciseId, bool isSuccessful, string? feedback = null)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("Student id cannot be empty.", nameof(studentId));
        }

        if (exerciseId == Guid.Empty)
        {
            throw new ArgumentException("Exercise id cannot be empty.", nameof(exerciseId));
        }

        return new Attempt(Guid.NewGuid(), studentId, exerciseId, isSuccessful, DateTime.UtcNow, feedback);
    }
}
