using System;
using System.ComponentModel.DataAnnotations;

namespace _2020_PAPP1_2.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int Ano { get; set; }

        //[Required(ErrorMessage = "{0} required")]
        public string Foto { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public bool Vendido { get; set; } = false;
    }
}
