using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoBemSolution.Models
{
    public class Usuario
    {
        [Key]
        public int Id{ get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Senha")]
        public string Password { get; set; }

        public bool IsBlocked { get; set; }


        [ForeignKey("Aluno")]
        public int IdAluno { get; set; }
        public virtual Aluno? Aluno { get; set; }

    }
}
