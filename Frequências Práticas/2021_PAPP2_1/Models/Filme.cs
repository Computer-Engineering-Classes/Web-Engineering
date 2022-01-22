using System.ComponentModel.DataAnnotations;

namespace Freq2.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} necessário.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "{0} necessária.")]
        [Display(Name = "Duração")]
        [Range(0, int.MaxValue, ErrorMessage = "A {0} deve ser igual ou superior a {1} minutos.")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "{0} necessário.")]
        public bool Estado { get; set; } = true;
    }
}
