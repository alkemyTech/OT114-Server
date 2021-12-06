﻿using System.ComponentModel.DataAnnotations;

namespace OngProject.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
