﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string LastName {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string EmailUser { get; set; }

    }
}
