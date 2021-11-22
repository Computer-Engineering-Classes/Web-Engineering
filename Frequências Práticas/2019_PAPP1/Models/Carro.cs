using System.ComponentModel.DataAnnotations;

namespace _2019_PAPP1.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Equipa { get; set; }
    }
}
