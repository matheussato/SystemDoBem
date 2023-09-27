﻿// <auto-generated />
using System;
using DobemSolution.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace DobemSolution.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    partial class OracleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoBemSolution.Models.Aluno", b =>
                {
                    b.Property<int>("IdAluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAluno"));

                    b.Property<int>("Id")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdTurma")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("RegistroAluno")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdAluno");

                    b.HasIndex("Id");

                    b.HasIndex("IdTurma");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("DoBemSolution.Models.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCurso"));

                    b.Property<string>("CargaHorariaCurso")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NomeCurso")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("DoBemSolution.Models.Feedback", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("autorizacao")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("estrelas")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("texto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("DoBemSolution.Models.Turma", b =>
                {
                    b.Property<int>("IdTurma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTurma"));

                    b.Property<DateTime>("Encerramento")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("IdCurso")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("IdTurma");

                    b.HasIndex("IdCurso");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("DoBemSolution.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("IdAluno")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("DoBemSolution.Models.Aluno", b =>
                {
                    b.HasOne("DoBemSolution.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoBemSolution.Models.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("IdTurma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DoBemSolution.Models.Turma", b =>
                {
                    b.HasOne("DoBemSolution.Models.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("DoBemSolution.Models.Usuario", b =>
                {
                    b.HasOne("DoBemSolution.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("DoBemSolution.Models.Curso", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("DoBemSolution.Models.Turma", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
