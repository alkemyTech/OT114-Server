using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Slide
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public int Order { get; set; }
        
        [Required]
        public Organization Organization { get; set; }
    }
}
