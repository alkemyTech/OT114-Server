using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Contact
    {
        //Al completar el Formulario de Contacto, se almacenará en la base de datos.
        //Nombre de tabla: contacts.
        //Contendrá los campos name, phone, email, message, deletedAt (utilizada para soft delete)

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool deleteAt { get; set; }

    }
}
