using System;
using System.ComponentModel.DataAnnotations;

namespace _2018_PAPP1.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.DateTime)]
        public DateTime DataRegisto { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Nível")]
        [Required(ErrorMessage = "{0} required")]
        public int NivelCliente { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Telefone { get; set; }

    }
}
