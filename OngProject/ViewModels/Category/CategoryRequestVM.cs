using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.ViewModels.Category
{
    public class CategoryRequestVM
    {
        [Required]
        public string Name { get; set; }
    }
}
