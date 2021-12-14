using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OngProject.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(6)]

        public string Username { get; set; }

        [Required]
        [MinLength(6)]

        public string Password { get; set; }
    }
}
