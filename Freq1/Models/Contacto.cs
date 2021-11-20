using System.ComponentModel.DataAnnotations;

namespace Freq1.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [MinLength(4, ErrorMessage = "{0} must have at least {1} characters")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public bool Amigo { get; set; } = false;
    }
}
