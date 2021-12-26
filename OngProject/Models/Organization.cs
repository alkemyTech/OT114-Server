﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Image { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Phone { get; set; }

        public DateTime? deletedAt { get; set; } = DateTime.Now;

        public Slide Slide { get; set; }
    }
}
