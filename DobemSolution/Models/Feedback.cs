using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DoBemSolution.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { set; get; }

        [Required]
        [DisplayName("Nome")]
        public string nome { set; get; }

        [Required]
        [DisplayName("Texto")]
        public string texto { set; get; }

        [Required]
        [Range(1, 5)]
        [DisplayName("Estrelas")]
        public int estrelas { set; get; }

        [Required]
        [DisplayName("Autorização")]
        public bool autorizacao { set; get; }


        [DisplayName("Curso")]
        public int? CursoId { get; set; }
        public Curso Curso { get; set; }
    
    }
}
