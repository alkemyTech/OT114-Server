using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.ViewModels
{
    public class CategoriesResponseVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
