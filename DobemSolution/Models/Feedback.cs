using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DoBemSolution.Models
{
    public class Feedback
    {
        [Key]
        public int id { set; get; }

        [Required]
        [DisplayName("Nome")]
        public string nome { set; get; }

        [Required]
        [DisplayName("Texto")]
        public string texto { set; get; }

        [Required]
        [DisplayName("Estrelas")]
        public int estrelas { set; get; }

        [Required]
        [DisplayName("Autorização")]
        public bool autorizacao { set; get; }
    }
}
