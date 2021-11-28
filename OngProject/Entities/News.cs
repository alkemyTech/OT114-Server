using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Image { get; set; }

        public DateTimeOffset Date { get; set; } = DateTime.Now; 

        public bool IsDeleted { get; set; } = false;
    }
}
