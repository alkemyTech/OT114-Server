﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }

        [Required]
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
