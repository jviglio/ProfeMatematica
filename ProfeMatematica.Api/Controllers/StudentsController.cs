using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfeMatematica.Application.Students;
using ProfeMatematica.Domain.Entities;
using ProfeMatematica.Infrastructure;

namespace ProfeMatematica.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ProfeMatematicaDbContext _db;

    public StudentsController(ProfeMatematicaDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentRequest request)
    {
        var student = Student.Create(
            request.Nombre,
            request.Email,
            request.Curso);

        _db.Students.Add(student);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = student.Id }, student);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _db.Students
            .AsNoTracking()
            .ToListAsync();

        return Ok(students);
    }
}