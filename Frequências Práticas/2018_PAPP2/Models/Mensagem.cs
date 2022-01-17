using System;
using System.ComponentModel.DataAnnotations;

namespace _2018_PAPP2.Models
{
    public class Mensagem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string IdUser { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Autor")]
        public string NomeUser { get; set; }

        [Required]
        [StringLength(5000)]
        [Display(Name = "Conteúdo")]
        public string Corpo { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
