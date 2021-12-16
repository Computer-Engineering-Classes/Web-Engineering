using System.ComponentModel.DataAnnotations;

namespace Aula11.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
