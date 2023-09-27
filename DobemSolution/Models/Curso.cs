using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoBemSolution.Models
{
    public class Curso
    {

        [Key]
        public int IdCurso { get; set; }

        [Required]
        public string NomeCurso { get; set; }
        
        [Required]
        public string CargaHorariaCurso { get; set; }

        [ForeignKey("Turma")]
        public int IdTurma { get; set; }
        public virtual Turma? Turma { get; set; }
    }
}
