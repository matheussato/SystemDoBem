using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoBemSolution.Models
{
    public class Turma
    {

        [Key]
        public int IdTurma { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Encerramento { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }

        [ForeignKey("Curso")]
        public int IdCurso { get; set; }
        public virtual Curso? Curso { get; set; }
    }
    
}
