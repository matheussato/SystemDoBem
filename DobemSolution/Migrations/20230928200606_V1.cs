using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DobemSolution.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCurso = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CargaHorariaCurso = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estrelas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    autorizacao = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CursoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedback_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "IdCurso");
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    IdTurma = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Inicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Encerramento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IdCurso = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK_Turma_Curso_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdAluno = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    RegistroAluno = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NomeAluno = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EmailAluno = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SenhaAluno = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdTurma = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdTurma",
                table: "Aluno",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CursoId",
                table: "Feedback",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma",
                column: "IdCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
