using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Comments
    {
        public int Id { get; set; }

        /// Consultar al mentor tipo de dato ///
        public string Body { get; set; }
        
        public User UserId { get; set; }

        // TODO : Relacionar modelo ///
        public News NewsId { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now; //no lo pedia pero en el ticket decia de ordenar por fecha, preguntar
    }
}
