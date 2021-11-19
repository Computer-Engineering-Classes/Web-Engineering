using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula4.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} length must be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(256, ErrorMessage = "{0} length can not exceed {1} characters")]
        public string Description { get; set; }

        public int Credits { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public bool State { get; set; } = true;

        [Required(ErrorMessage = "Required field")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
