using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DobemSolution.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
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
                    IdCurso = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CursoIdCurso = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedback_Curso_CursoIdCurso",
                        column: x => x.CursoIdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IsBlocked = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IdAluno = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "IdAluno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Id",
                table: "Aluno",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdTurma",
                table: "Aluno",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CursoIdCurso",
                table: "Feedback",
                column: "CursoIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdAluno",
                table: "Usuario",
                column: "IdAluno");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Usuario_Id",
                table: "Aluno",
                column: "Id",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_IdTurma",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Usuario_Id",
                table: "Aluno");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
