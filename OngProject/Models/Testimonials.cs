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
        public string Name { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public DateTime DeletedAt { get; set; }
   
    }
}
