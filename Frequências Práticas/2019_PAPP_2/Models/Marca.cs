using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _2019_PAPP_2.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} necessário")]
        public string Nome { get; set; }

        public virtual ICollection<Carro> Carros { get; set; }
    }
}
