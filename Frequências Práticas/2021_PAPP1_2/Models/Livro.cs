using System.ComponentModel.DataAnnotations;

namespace _2021_PAPP1_2.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        public string Autores { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]-[0-9]{2}-[0-9]{6}-[0-9]", ErrorMessage = "Invalid {0}")]
        public string ISBN { get; set; }

        public string Capa { get; set; }

        public string Contracapa { get; set; }
    }
}
