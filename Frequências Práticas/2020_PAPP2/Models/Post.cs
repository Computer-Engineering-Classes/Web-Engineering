using System;
using System.ComponentModel.DataAnnotations;

namespace _2020_PAPP2.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int Likes { get; set; }
    }
}
