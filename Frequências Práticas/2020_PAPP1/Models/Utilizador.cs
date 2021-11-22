using System.ComponentModel.DataAnnotations;

namespace _2020_PAPP1.Models
{
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "{0} required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "{0} must have minimum length of {1} characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Tipo { get; set; }

    }
}
