using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        /// Consultar al mentor tipo de dato ///
        public string Body { get; set; }
        
        public User UserId { get; set; }

        // TODO : Relacionar modelo ///
        //public News NewsId { get; set; }
    }
}
