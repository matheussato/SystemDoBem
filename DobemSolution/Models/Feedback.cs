using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoBemSolution.Models
{
    public class Feedback
    {
        [Key]
        public int id { set; get; }

        [Required]
        public string nome { set; get; }

        [Required]    
        public string texto { set; get; }

        [Required]
        public int estrelas { set; get; }

        [Required]
        public bool autorizacao { set; get; }
    }
}
