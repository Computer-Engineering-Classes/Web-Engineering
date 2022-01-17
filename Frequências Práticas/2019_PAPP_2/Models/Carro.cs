using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2019_PAPP_2.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} maior que 0")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        [MaxLength(20, ErrorMessage = "Máximo de {1} caracteres")]
        public string Piloto { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "{0} deverá ser igual ou superior a {1}")]
        public int Pontos { get; set; } = 0;

        [Required]
        [ForeignKey("Marca")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        public Marca Marca { get; set; }
    }
}
