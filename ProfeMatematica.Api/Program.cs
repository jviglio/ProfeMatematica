using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProfeMatematica.Application.Students;
using ProfeMatematica.Domain.Entities;
using ProfeMatematica.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProfeMatematicaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/students", async Task<Created<Student>> (
    CreateStudentRequest request,
    ProfeMatematicaDbContext dbContext) =>
{
    var student = Student.Create(request.Nombre);

    dbContext.Students.Add(student);
    await dbContext.SaveChangesAsync();

    return TypedResults.Created($"/students/{student.Id}", student);
});

app.MapGet("/students", async Task<Ok<List<Student>>> (ProfeMatematicaDbContext dbContext) =>
{
    var students = await dbContext.Students
        .AsNoTracking()
        .ToListAsync();

    return TypedResults.Ok(students);
});

app.Run();
