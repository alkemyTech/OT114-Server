using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Organization
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int Image { get; set; }

        [StringLength(20)]
        [Required]
        public string Address { get; set; }
        
        public int Phone { get; set; }

        public Member Miembros { get; set; }

    public DateTime? deletedAt { get; set; } = DateTime.Now;
    }
}
