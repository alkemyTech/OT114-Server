using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public string Apellido { get; set; }

        [Required]
        public string EmailUsuario { get; set; }

        [Required]
        public string Contraseña { get; set; }
    }
}
