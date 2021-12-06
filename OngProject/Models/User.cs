using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class User
    {
        /*Campos:
id: INTEGER NOT NULL AUTO_INCREMENT
firstName: VARCHAR NOT NULL
lastName: VARCHAR NOT NULL
email: VARCHAR UNIQUE NOT NULL
password: VARCHAR NOT NULL
photo: VARCHAR NULLABLE
roleId: Clave foranea hacia ID de Role
timestamps y softDeletes*/

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Photo { get; set; }

        public DateTime Timestamps { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } //para el soft-delete: IsActive= false (inactivo/baja lógica) IsActive=true (Activo)
        public int roleID { get; set; } //aquí tiene que ir la clase Role con lo de mi otro compañero

        public Roles role { get; set; } //Verificar aquí
    }
}
