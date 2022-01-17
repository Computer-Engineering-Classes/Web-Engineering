using System.ComponentModel.DataAnnotations;

namespace _2018_PAPP2.Models
{
    public class Interessado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string IdUser { get; set; }
    }
}
