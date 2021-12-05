using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OngProject.ViewModels
{
    public class RegistrationRequestViewModel
    {
        [Required]
        [MinLength(6)]

        public string Username { get; set; }

        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        [MinLength(6)]

        public string Password { get; set; }
    }
}
