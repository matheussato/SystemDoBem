using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DoBemSolution.Models
{
    public class Aluno
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAluno { get; set; }

        [Required]
        [DisplayName("Código do Aluno")]
        public string? RegistroAluno { get; set; }


        [ForeignKey("Usuario")]
        [DisplayName("Usuario")]
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }


        [ForeignKey("Turma")]
        [DisplayName("Turma")]
        public int IdTurma { get; set; }
        public virtual Turma? Turma { get; set; }




    }
}

