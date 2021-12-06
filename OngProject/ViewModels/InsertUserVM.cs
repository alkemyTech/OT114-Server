using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.ViewModels
{
    public class InsertUserVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

        public DateTime Timestamps { get; set; }
        public bool IsActive { get; set; } //para el soft-delete: IsActive= false (inactivo/baja lógica) IsActive=true (Activo)
    }
}


