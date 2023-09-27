using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoBemSolution.Models
{
    public class Turma
    {

        [Key]
        public int IdTurma { get; set; }

        [Required]
        [DisplayName("Data de Início")]
        public DateTime Inicio { get; set; }

        [Required]
        [DisplayName("Data do Término")]
        public DateTime Encerramento { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }

        [ForeignKey("Curso")]
        [DisplayName("Curso")]
        public int IdCurso { get; set; }
        public virtual Curso? Curso { get; set; }
    }
    
}
