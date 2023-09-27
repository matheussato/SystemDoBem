using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoBemSolution.Models
{
    public class Usuario
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsBlocked { get; set; }


        [ForeignKey("Aluno")]
        public int IdAluno { get; set; }
        public virtual Aluno? Aluno { get; set; }

    }
}
