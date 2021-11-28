using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Organizacion
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public byte[] Image { get; set; }
        
        public string Adress { get; set; }

        public int? Phone { get; set; }
        
        public string Email { get; set; }

        public string WelcomeText { get; set; }

        public string AboutUsText { get; set; }

        public DateTime TimeStamps { get; set; } = DateTime.Now;

    }
}
