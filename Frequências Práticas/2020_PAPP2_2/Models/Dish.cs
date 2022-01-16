using System.ComponentModel.DataAnnotations;

namespace _2020_PAPP2_2.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "{0} must be positive number.")]
        public decimal Price { get; set; }

        public string User { get; set; }
    }
}
