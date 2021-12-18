using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public string Order { get; set; }
        public int OrderId { get; set; }
        public int OrganizacionId { get; set; }
    }
}
