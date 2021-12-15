using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime? deletedAt { get; set; } = DateTime.Now;
    }
}
