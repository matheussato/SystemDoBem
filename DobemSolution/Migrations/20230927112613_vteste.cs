using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DobemSolution.Migrations
{
    /// <inheritdoc />
    public partial class vteste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Turma_IdTurma",
                table: "Curso");

            migrationBuilder.DropIndex(
                name: "IX_Curso_IdTurma",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "IdTurma",
                table: "Curso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTurma",
                table: "Curso",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdTurma",
                table: "Curso",
                column: "IdTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Turma_IdTurma",
                table: "Curso",
                column: "IdTurma",
                principalTable: "Turma",
                principalColumn: "IdTurma",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
