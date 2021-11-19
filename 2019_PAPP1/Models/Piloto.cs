using System.ComponentModel.DataAnnotations;

namespace _2019_PAPP1.Models
{
    public class Piloto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int Pontos { get; set; } = 0;

        public Carro Carro { get; set; }
    }
}
