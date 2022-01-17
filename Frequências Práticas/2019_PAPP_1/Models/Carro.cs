using System.ComponentModel.DataAnnotations;

namespace _2019_PAPP.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} necessário.")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage ="{0} necessária.")]
        public string Equipa { get; set; }
    }
}
