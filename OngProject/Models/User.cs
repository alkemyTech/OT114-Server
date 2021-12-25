using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OngProject.Models
{
    public class User : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int IdUser { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //[Required]
        //public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Photo { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Roles roleID { get; set; }
        public string MyToken { get; set; }
    }
}
