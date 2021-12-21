using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Testimonials
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(500)]
        public string Content { get; set; }
        public DateTime? DeletedAt { get; set; }
   
    }
}
