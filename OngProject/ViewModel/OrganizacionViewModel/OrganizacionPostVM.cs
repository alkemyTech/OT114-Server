using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.ViewModel.OrganizacionViewModel
{
    public class OrganizacionPostVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Image { get; set; }

        public string Adress { get; set; }

        public int? Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WelcomeText { get; set; }

        public string AboutUsText { get; set; }

        public DateTime TimeStamps { get; set; }
    }
}
