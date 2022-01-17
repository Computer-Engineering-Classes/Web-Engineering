using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2019_PAPP.Models
{
    public class Piloto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} necessário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="{0} necessários.")]
        [Range(0, int.MaxValue, ErrorMessage = "{0} tem de ser igual ou superior a {1}.")]
        public int Pontos { get; set; } = 0;

        [ForeignKey("Carro")]
        public int? CarroId { get; set; } 

        public Carro Carro { get; set; }
    }
}
