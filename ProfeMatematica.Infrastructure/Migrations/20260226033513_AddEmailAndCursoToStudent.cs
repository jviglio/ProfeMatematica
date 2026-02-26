using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfeMatematica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAndCursoToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Curso",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curso",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");
        }
    }
}
