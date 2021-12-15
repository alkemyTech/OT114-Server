using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        public string Body { get; set; }
        
        public User UserId { get; set; }

        public News NewsId { get; set; }
    }
}
