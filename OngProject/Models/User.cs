using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace OngProject.Models
{
    public class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int IdUser { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
       // public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Photo { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Roles roleID { get; set; } 
    }
}
