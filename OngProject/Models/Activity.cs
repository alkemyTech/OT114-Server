using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public char Name { get; set; }
        public string Content { get; set; }
        public char Image { get; set; }
        public DateTime? deletedAt { get; set; } = null;
    }
}