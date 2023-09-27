using DoBemSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace DobemSolution.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Feedback> Feedback { set; get; }
        public DbSet<Usuario> Usuario { set; get; }

        public OracleDbContext(DbContextOptions options) : base(options) { }
    }
}
