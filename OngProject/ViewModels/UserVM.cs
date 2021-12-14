using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public DateTime Timestamps { get; set; }
    }
}
