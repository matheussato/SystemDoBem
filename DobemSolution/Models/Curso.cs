using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoBemSolution.Models
{
    public class Curso
    {

        [Key]
        public int IdCurso { get; set; }

        [Required]
        [DisplayName("Nome do Curso")]
        public string NomeCurso { get; set; }
        
        [Required]
        [DisplayName("Carga Horario")]
        public string CargaHorariaCurso { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }


        public virtual ICollection<Feedback> Feedbacks { get; set; }

    }
}
