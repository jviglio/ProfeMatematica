namespace ProfeMatematica.Application.Students;

public sealed class CreateStudentRequest
{
    public string Nombre { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Curso { get; set; } = string.Empty;
}
