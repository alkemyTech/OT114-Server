using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Models
{
    public class Roles
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = null!;
        [MaxLength(250)]
        public string Description { get; set; }
        public DateTime Timestamps { get; set; } = DateTime.Now;
    }
}
