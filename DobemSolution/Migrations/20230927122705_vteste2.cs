using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DobemSolution.Migrations
{
    /// <inheritdoc />
    public partial class vteste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoIdCurso",
                table: "Feedback",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCurso",
                table: "Feedback",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CursoIdCurso",
                table: "Feedback",
                column: "CursoIdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Curso_CursoIdCurso",
                table: "Feedback",
                column: "CursoIdCurso",
                principalTable: "Curso",
                principalColumn: "IdCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Curso_CursoIdCurso",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_CursoIdCurso",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "CursoIdCurso",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "IdCurso",
                table: "Feedback");
        }
    }
}
