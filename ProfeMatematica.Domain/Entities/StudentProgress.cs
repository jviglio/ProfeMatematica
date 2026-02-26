using ProfeMatematica.Domain.Common;

namespace ProfeMatematica.Domain.Entities;

public sealed class StudentProgress : Entity
{
    private StudentProgress(Guid id, Guid studentId, DateTime createdAt) : base(id, createdAt)
    {
        StudentId = studentId;
    }

    public Guid StudentId { get; }

    public int SuccessfulAttempts { get; private set; }

    public int FailedAttempts { get; private set; }

    public int CurrentStreak { get; private set; }

    public int TotalAttempts => SuccessfulAttempts + FailedAttempts;

    public static StudentProgress Create(Guid studentId)
    {
        if (studentId == Guid.Empty)
        {
            throw new ArgumentException("Student id cannot be empty.", nameof(studentId));
        }

        return new StudentProgress(Guid.NewGuid(), studentId, DateTime.UtcNow);
    }

    public void RegisterSuccess()
    {
        SuccessfulAttempts++;
        CurrentStreak++;
    }

    public void RegisterFailure()
    {
        FailedAttempts++;
        CurrentStreak = 0;
    }
}
