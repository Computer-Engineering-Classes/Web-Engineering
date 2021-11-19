using System.ComponentModel.DataAnnotations;

namespace Aula3.Models
{
    public class FileViewModel
    {
        [Required]
        [RegularExpression(@"^.+\.([pP][dD][fF])$", ErrorMessage = "Only PDF Files")]
        public string Name { get; set; }

        [Display(Name = "Size in Bytes")]
        public long Size { get; set; }
    }
}
