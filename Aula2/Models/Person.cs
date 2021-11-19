using System;
using System.ComponentModel.DataAnnotations;

namespace Aula2.Models
{
    public class Person
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "The field {0} is required")]
        public string Name { get; set; }

        [Display(Name = "Idade")]
        [Required(ErrorMessage = "The field {0} is required")]
        [Range(18, 100, ErrorMessage = "{0} must be a value between {1} and {2}")]
        public int Age { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Endereço de email")]
        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
