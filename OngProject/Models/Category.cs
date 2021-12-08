using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime deletedAt { get; set; } = DateTime.Now;
    }
}
